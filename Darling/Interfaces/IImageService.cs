namespace Darling.Interfaces;

internal interface IImageService
{
    (bool, Point?) FindImage(
        string filepathSource,
        string filepathToSearch,
        double threshold = 0.9,
        PictureBox? debugPictureBox = null,
        TextBox? debugTextBox = null);
}
