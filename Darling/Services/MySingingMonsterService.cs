﻿namespace Darling.Services;

internal class MySingingMonsterService : IMySingingMonsterService
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ITesseractService _tesseractService;
    private readonly IImageService _imageService;
    private readonly ILogService _logService;

    private static IntPtr WindowHandler { get; set; }
    private static Process? GameProcess { get; set; }

    public MySingingMonsterService(
        IHostEnvironment hostEnvironment,
        ITesseractService tesseractService,
        IImageService imageService,
        ILogService logService)
    {
        _hostEnvironment = hostEnvironment;
        _tesseractService = tesseractService;
        _imageService = imageService;
        _logService = logService;
    }

    /** Public **
     * FindGameProcess <- bool
     * RecoverAllResources <- void
     * RecoverAllResourcesCheck <- void
     * RecoverAllResourcesConfirm <- void
     * RecoverAllResourcesCloseOnFail <- void
     * RecoverAllDiamonds <- void
     * NextIsland <- void
     * CloseBanner <- void
     * IsPaused <- bool
     * Play <- void
     */

    #region Public
    public bool FindGameProcess()
    {
        if (IsProcessActive()) return true;

        (WindowHandler, GameProcess) = ProcessHelper.FindProcess();

        if (!IsProcessActive())
        {
            WindowHandler = IntPtr.Zero;
            GameProcess = null;
            return false;
        }

        return true;
    }

    public void RecoverAllResources()
    {
        var click = GetMouseClickPosition(AppConstants.ImageElements.ButtonGetAll);
        if (click == null) return;

        MouseHelper.LeftClick(click.Value);
    }
    #endregion

    /** Private **
     * IsProcessActive <- bool
     * GetActualPicturePath <- string
     * GetMouseClickPosition <- Point?
     */

    #region Private
    private bool IsProcessActive()
    {
        return WindowHandler != IntPtr.Zero && !(GameProcess?.HasExited ?? true);
    }

    private (Rectangle?, string) GetActualPicturePath()
    {
        if (!IsProcessActive()) return (null, string.Empty);
        WindowHelper.SetWindowToTopFront(WindowHandler);
        var rect = WindowHelper.GetWindowRectangle(WindowHandler);
        var path = WindowHelper.TakeScreenshot(rect);
        return string.IsNullOrEmpty(path) ? (null, string.Empty) : (rect, path);
    }

    private Point? GetMouseClickPosition(string imgToSearchName)
    {
        if (!IsProcessActive()) return null;
        
        (Rectangle? windowPos, string screenshotPath) = GetActualPicturePath();

        var imagePathToFind = Path.Combine(_hostEnvironment.ContentRootPath, imgToSearchName);

        (bool found, Point? btnCenter) = _imageService.FindImage(screenshotPath, imagePathToFind, AppConstants.ImageProcessing.ImageThreshold);

        if (!found || !btnCenter.HasValue) return null;

        Point windowLUCorner = windowPos?.Location ?? Point.Empty;
        Point btnPoint = btnCenter.Value;

        return new Point(windowLUCorner.X + btnPoint.X, windowLUCorner.Y + btnPoint.Y);
    }
    #endregion

    //var text = _tesseractService.GetStringFromImage(path, 0.8f, 0.7f, 1f, 1f);
    //textBox1.Text = text + Environment.NewLine + textBox1.Text;
}
