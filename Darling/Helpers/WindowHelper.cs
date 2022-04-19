using Darling.Structs;

namespace Darling.Helpers;

internal static partial class WindowHelper
{
    [DllImport("dwmapi.dll")]
    static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out WindowRect pvAttribute, int cbAttribute);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hwnd, out WindowRect lpRect);

    public static Rectangle GetWindowRectangle(IntPtr handle)
    {
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

        return rect.ToRectangle();
    }

    public static string TakeScreenshot(Rectangle rc)
    {
        using Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        using Graphics gfxBmp = Graphics.FromImage(bmp);

        gfxBmp.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);

        //using MemoryStream ms = new MemoryStream();
        //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

        using FileStream fs = new FileStream(MainForm.Constants.ImageFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite | FileShare.Delete);
        bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

        return fs.Name;
    }
}
