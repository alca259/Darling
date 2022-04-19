namespace Darling.Interfaces;

internal interface ITesseractService
{
    Rect GetRect(float x1Percent, float x2Percent, float y1Percent, float y2Percent, int width, int height);
    string GetStringFromImage(string imagePath);
    string GetStringFromImage(string imagePath, float x1Percent, float y1Percent, float x2Percent, float y2Percent);
    string GetStringFromImage(string imagePath, int x1, int y1, int x2, int y2);
    string GetStringFromImage(byte[] imageFile);
    string GetStringFromImage(byte[] imageFile, float x1Percent, float y1Percent, float x2Percent, float y2Percent);
    string GetStringFromImage(byte[] imageFile, int x1, int y1, int x2, int y2);
}
