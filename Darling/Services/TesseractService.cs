namespace Darling.Services;

internal class TesseractService : ITesseractService
{
    private const string Language = "spa";
    private static string? TessDataPath;
    private readonly IHostEnvironment _environment;

    public TesseractService(IHostEnvironment environment)
    {
        _environment = environment;
        TessDataPath = Path.Combine(_environment.ContentRootPath, "tessdata");
    }

    #region Tesseract
    public Rect GetRect(double x1Percent, double x2Percent, double y1Percent, double y2Percent, int width, int height)
    {
        int x1 = Convert.ToInt32(Math.Round(width * x1Percent, 0));
        int x2 = Convert.ToInt32(Math.Round(width * x2Percent, 0));
        int y1 = Convert.ToInt32(Math.Round(height * y1Percent, 0));
        int y2 = Convert.ToInt32(Math.Round(height * y2Percent, 0));

        return Rect.FromCoords(x1, y1, x2, y2);
    }

    /// <summary>
    /// Gets all the text as string from image.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <returns></returns>
    public string GetStringFromImage(string? imagePath)
    {
        var textValue = string.Empty;
        if (string.IsNullOrEmpty(imagePath) == false && File.Exists(imagePath) == true)
        {
            try
            {
                using var engine = new TesseractEngine(TessDataPath, Language, EngineMode.Default);
                using var img = Pix.LoadFromFile(imagePath);
                using var page = engine.Process(img, pageSegMode: PageSegMode.Auto);
                textValue = page.GetText().Replace("\n", " ").Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
        return textValue;
    }

    /// <summary>
    /// Gets all the text as string from image.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="x1Percent">Valor en porcentaje</param>
    /// <param name="y1Percent">Valor en porcentaje</param>
    /// <param name="x2Percent">Valor en porcentaje</param>
    /// <param name="y2Percent">Valor en porcentaje</param>
    /// <returns></returns>
    public string GetStringFromImage(string? imagePath, double x1Percent, double y1Percent, double x2Percent, double y2Percent)
    {
        var textValue = string.Empty;
        if (string.IsNullOrEmpty(imagePath) == false && File.Exists(imagePath) == true)
        {
            try
            {
                using var engine = new TesseractEngine(TessDataPath, Language, EngineMode.Default);
                using var img = Pix.LoadFromFile(imagePath);
                var rect = GetRect(x1Percent, x2Percent, y1Percent, y2Percent, img.Width, img.Height);
                using var page = engine.Process(img, rect, PageSegMode.Auto);
                textValue = page.GetText().Replace("\n", " ").Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
        return textValue;
    }

    /// <summary>
    /// Gets all the text as string from image.
    /// </summary>
    /// <param name="imagePath">The image path.</param>
    /// <param name="x1">Valor en pixels</param>
    /// <param name="y1">Valor en pixels</param>
    /// <param name="x2">Valor en pixels</param>
    /// <param name="y2">Valor en pixels</param>
    /// <returns></returns>
    public string GetStringFromImage(string? imagePath, int x1, int y1, int x2, int y2)
    {
        var textValue = string.Empty;
        if (string.IsNullOrEmpty(imagePath) == false && File.Exists(imagePath) == true)
        {
            try
            {
                using var engine = new TesseractEngine(TessDataPath, Language, EngineMode.Default);
                using var img = Pix.LoadFromFile(imagePath);
                var rect = Rect.FromCoords(x1, y1, x2, y2);
                using var page = engine.Process(img, rect, PageSegMode.Auto);
                textValue = page.GetText().Replace("\n", " ").Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
        return textValue;
    }

    /// <summary>
    /// Gets all the text as string from image.
    /// </summary>
    /// <param name="imageFile">The image byte array.</param>
    /// <returns></returns>
    public string GetStringFromImage(byte[] imageFile)
    {
        var textValue = string.Empty;
        if (imageFile == null) return textValue;

        try
        {
            using var engine = new TesseractEngine(TessDataPath, Language, EngineMode.Default);
            using var img = Pix.LoadFromMemory(imageFile);
            using var page = engine.Process(img, pageSegMode: PageSegMode.Auto);
            textValue = page.GetText().Replace("\n", " ").Trim();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }

        return textValue;
    }

    /// <summary>
    /// Gets all the text as string from image.
    /// </summary>
    /// <param name="imageFile">The image byte array.</param>
    /// <param name="x1Percent">Valor en porcentaje</param>
    /// <param name="y1Percent">Valor en porcentaje</param>
    /// <param name="x2Percent">Valor en porcentaje</param>
    /// <param name="y2Percent">Valor en porcentaje</param>
    /// <returns></returns>
    public string GetStringFromImage(byte[] imageFile, double x1Percent, double y1Percent, double x2Percent, double y2Percent)
    {
        var textValue = string.Empty;
        if (imageFile == null) return textValue;

        try
        {
            using var engine = new TesseractEngine(TessDataPath, Language, EngineMode.Default);
            using var img = Pix.LoadFromMemory(imageFile);
            var rect = GetRect(x1Percent, x2Percent, y1Percent, y2Percent, img.Width, img.Height);
            using var page = engine.Process(img, rect, PageSegMode.Auto);
            textValue = page.GetText().Replace("\n", " ").Trim();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }

        return textValue;
    }

    /// <summary>
    /// Gets all the text as string from image.
    /// </summary>
    /// <param name="imageFile">The image byte array.</param>
    /// <param name="x1">Valor en pixels</param>
    /// <param name="y1">Valor en pixels</param>
    /// <param name="x2">Valor en pixels</param>
    /// <param name="y2">Valor en pixels</param>
    /// <returns></returns>
    public string GetStringFromImage(byte[] imageFile, int x1, int y1, int x2, int y2)
    {
        var textValue = string.Empty;
        if (imageFile == null) return textValue;

        try
        {
            using var engine = new TesseractEngine(TessDataPath, Language, EngineMode.Default);
            using var img = Pix.LoadFromMemory(imageFile);
            var rect = Rect.FromCoords(x1, y1, x2, y2);
            using var page = engine.Process(img, rect, PageSegMode.Auto);
            textValue = page.GetText().Replace("\n", " ").Trim();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }

        return textValue;
    }
    #endregion
}
