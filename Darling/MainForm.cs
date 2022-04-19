namespace Darling;
#pragma warning disable CS0162 // Se detectó código inaccesible

internal partial class MainForm : Form
{
    private readonly ITesseractService _tesseractService;
    private readonly IImageService _imageService;
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ILogService _logService;
    private const bool DebugMode = true;

    internal struct Constants
    {
        internal const string ProcessName = "MySingingMonsters";
        internal const string ImageFileName = "AlcaTempFile.jpg";
    }

    public MainForm(
        ITesseractService tesseractService,
        IImageService imageService,
        IHostEnvironment hostEnvironment,
        ILogService logService)
    {
        InitializeComponent();
        _tesseractService = tesseractService;
        _imageService = imageService;
        _hostEnvironment = hostEnvironment;
        _logService = logService;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string? path;
        if (DebugMode)
        {
            (IntPtr windowHandle, IntPtr processHandle) = ProcessHelper.FindProcess();
            if (windowHandle == IntPtr.Zero) return;

            var rect = WindowHelper.GetWindowRectangle(windowHandle);
            textBox1.PrependTextWithNewLine(rect.ToString());

            path = WindowHelper.TakeScreenshot(rect);
            if (string.IsNullOrEmpty(path)) return;
        }
        else
        {
            var fileName = "UI_WithCoins.jpg";
            //fileName = "UI_Clean.jpg";
            path = Path.Combine(_hostEnvironment.ContentRootPath, "Content", "Demo", fileName);
        }

        var pathToFind = Path.Combine(_hostEnvironment.ContentRootPath, "Content", "Elements", "button_getdiamond.jpg");

        (bool found, Point? btnCenter) = _imageService.FindImage(path, pathToFind, 0.65, pictureBox1, textBox1);

        //var text = _tesseractService.GetStringFromImage(path, 0.8f, 0.7f, 1f, 1f);
        //textBox1.Text = text + Environment.NewLine + textBox1.Text;
    }
}
