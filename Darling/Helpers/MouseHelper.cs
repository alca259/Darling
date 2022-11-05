namespace Darling.Helpers;

internal static class MouseHelper
{
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, int dwExtraInfo);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetCursorPos(int x, int y);

    private struct MouseEventFlags
    {
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        public const uint MOUSEEVENTF_XDOWN = 0x0080;
        public const uint MOUSEEVENTF_XUP = 0x0100;
        public const uint MOUSEEVENTF_WHEEL = 0x0800;
        public const uint MOUSEEVENTF_HWHEEL = 0x01000;
    }

    public static async Task LeftClick(Point? optionalPoint = null, CancellationToken token = default)
    {
        Point p = optionalPoint.HasValue ? optionalPoint.Value : AppInstance.Instance.CurrentProcess.ClickPoint;
        SetCursorPos(p.X, p.Y);
        mouse_event(MouseEventFlags.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        await Task.Delay(100, token);
        mouse_event(MouseEventFlags.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }

    public static async Task DoubleLeftClick(Point? optionalPoint = null, CancellationToken token = default)
    {
        Point p = optionalPoint.HasValue ? optionalPoint.Value : AppInstance.Instance.CurrentProcess.ClickPoint;
        SetCursorPos(p.X, p.Y);
        mouse_event(MouseEventFlags.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        await Task.Delay(300, token);
        mouse_event(MouseEventFlags.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
}
