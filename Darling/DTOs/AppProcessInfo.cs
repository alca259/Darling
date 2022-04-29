namespace Darling;

public class AppProcessInfo
{
    public IntPtr WindowHandler { get; private set; }
    public Process? GameProcess { get; private set; }
    public string CapturePath { get; set; } = string.Empty;
    public Rectangle LastWindowRect { get; set; }
    public Point LastWindowLocation => LastWindowRect.Location;
    public Point RightBottomPoint => new Point(LastWindowRect.Left + 100, LastWindowRect.Bottom - 10);
    public Point ClickPoint { get; private set; } = Point.Empty;

    public void SetHandlerProcess((IntPtr handle, Process? process) tuple)
    {
        WindowHandler = tuple.handle;
        GameProcess = tuple.process;
    }

    public void ClearProcess()
    {
        WindowHandler = IntPtr.Zero;
        GameProcess = null;
    }

    public bool IsProcessActive()
    {
        return WindowHandler != IntPtr.Zero && !(GameProcess?.HasExited ?? true);
    }

    public void SetClickPoint(Point btnCenter)
    {
        ClickPoint = new Point(LastWindowLocation.X + btnCenter.X, LastWindowLocation.Y + btnCenter.Y);
    }
}
