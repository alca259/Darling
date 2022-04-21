namespace Darling.Interfaces;

internal interface ITesseractService
{
    Rect GetRect(double x1Percent, double x2Percent, double y1Percent, double y2Percent, int width, int height);
    string GetStringFromImage(string? imagePath);
    string GetStringFromImage(string? imagePath, double x1Percent, double y1Percent, double x2Percent, double y2Percent);
    string GetStringFromImage(string? imagePath, int x1, int y1, int x2, int y2);
    string GetStringFromImage(byte[] imageFile);
    string GetStringFromImage(byte[] imageFile, double x1Percent, double y1Percent, double x2Percent, double y2Percent);
    string GetStringFromImage(byte[] imageFile, int x1, int y1, int x2, int y2);
}
