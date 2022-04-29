namespace Darling.Services;

internal class ImageService : IImageService
{
    private readonly ILogService _logService;

    public ImageService(ILogService logService)
    {
        _logService = logService;
    }

    public (bool, Point) FindImage(
        string filepathSource,
        string filepathToSearch,
        double threshold = 0.9,
        PictureBox? debugPictureBox = null,
        TextBox? debugTextBox = null)
    {
        Image<Bgr, byte> source = new Image<Bgr, byte>(filepathSource); // Image B
        Image<Bgr, byte> template = new Image<Bgr, byte>(filepathToSearch); // Image A
        Image<Bgr, byte> imageToShow = source.Copy();

        string message = string.Empty;
        bool found = false;
        Point point = Point.Empty;

        using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
        {
            double[] minValues, maxValues;
            Point[] minLocations, maxLocations;
            result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

            // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
            if (maxValues[0] > threshold)
            {
                // This is a match. Do something with it, for example draw a rectangle around it.
                Rectangle match = new Rectangle(maxLocations[0], template.Size);
                imageToShow.Draw(match, new Bgr(Color.Red), 3);

                found = true;
                point = match.GetCenter();
                message = $"Found some rectangle icon: {point} Threshold: {maxValues[0]}";
            }
        }

        if (found && debugTextBox != null)
        {
            debugTextBox.PrependTextWithNewLine(message);
        }

        if (debugPictureBox != null)
        {
            debugPictureBox.Image = found ? imageToShow.AsBitmap() : null;
        }

        if (found)
        {
            _logService.Log($"{message} - {Path.GetFileName(filepathToSearch)}");
        }

        return (found, point);
    }
}
