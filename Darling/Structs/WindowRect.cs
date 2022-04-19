namespace Darling.Structs;

[Serializable, StructLayout(LayoutKind.Sequential)]
public struct WindowRect
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;

    public Rectangle ToRectangle()
    {
        return Rectangle.FromLTRB(Left, Top, Right, Bottom);
    }
}
