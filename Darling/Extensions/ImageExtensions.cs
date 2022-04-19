namespace Darling.Extensions;

internal static class ImageExtensions
{
    public static Point GetCenter(this Rectangle rectangle)
    {
        int x = rectangle.Left;
        int y = rectangle.Top;
        int width = rectangle.Width;
        int height = rectangle.Height;

        x += width / 2;
        y += height / 2;

        return new Point(x, y);
    }
}
