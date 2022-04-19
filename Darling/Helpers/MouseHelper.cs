namespace Darling.Helpers;

internal static class MouseHelper
{
    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    private enum MouseEventFlags
    {
        LeftDown = 2,
        LeftUp = 4
    }

    public static void LeftClick(Point p)
    {
        mouse_event((int)MouseEventFlags.LeftDown, p.X, p.Y, 0, 0);
        mouse_event((int)MouseEventFlags.LeftUp, p.X, p.Y, 0, 0);
    }
}
