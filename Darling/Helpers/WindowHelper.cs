namespace Darling.Helpers;

internal static partial class WindowHelper
{
    const uint PW_RENDERFULLCONTENT = 0x00000002;

    [DllImport("dwmapi.dll")]
    static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out WindowRect pvAttribute, int cbAttribute);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hwnd, out WindowRect lpRect);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool BringWindowToTop(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, uint nFlags);

    public static void GetWindowRectangle()
    {
        IntPtr handle = AppSettings.Instance.CurrentProcess.WindowHandler;
        WindowRect rect = new WindowRect();

        if (Environment.OSVersion.Version.Major >= 6)
        {
            int size = Marshal.SizeOf(typeof(WindowRect));
            DwmGetWindowAttribute(handle, (int)DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, size);
        }
        else if (Environment.OSVersion.Version.Major < 6 || rect.ToRectangle().Width == 0)
        {
            GetWindowRect(handle, out rect);
        }

        AppSettings.Instance.CurrentProcess.LastWindowRect = rect.ToRectangle();
    }

    /*
     * Se puede hacer así, pero es más lento y requiere que la pantalla esté en primer plano
    public static async Task<string> TakeScreenshot(Rectangle rc)
    {
        using Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppPArgb);
        using Graphics gfxBmp = Graphics.FromImage(bmp);

        await Task.Delay(AppConstants.ProcessData.DelayThreadMilliseconds);
        gfxBmp.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);

        await Task.Delay(AppConstants.ProcessData.DelayThreadMilliseconds);
        using FileStream fs = new FileStream(AppConstants.ImageProcessing.ImageFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Delete);
        bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

        return fs.Name;
    }
    */

    public static void TakeScreenshot()
    {
        IntPtr handle = AppSettings.Instance.CurrentProcess.WindowHandler;
        Rectangle rc = AppSettings.Instance.CurrentProcess.LastWindowRect;

        using Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppPArgb);
        using Graphics gfxBmp = Graphics.FromImage(bmp);

        IntPtr hdc = gfxBmp.GetHdc();
        if (!PrintWindow(handle, hdc, PW_RENDERFULLCONTENT))
        {
            int error = Marshal.GetLastWin32Error();
            var exception = new Win32Exception(error);
            Log.Logger.Error(exception, exception.Message);
        }
        gfxBmp.ReleaseHdc(hdc);

        using FileStream fs = new FileStream(AppSettings.Instance.TempImageFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Delete);
        bmp.Save(fs, ImageFormat.Jpeg);

        AppSettings.Instance.CurrentProcess.CapturePath = fs.Name;
    }

    public static Task SetWindowToTopFront(CancellationToken token)
    {
        IntPtr handle = AppSettings.Instance.CurrentProcess.WindowHandler;
        BringWindowToTop(handle);
        return Task.Delay(AppSettings.Instance.Delays.WindowToTop, token);
    }
}
