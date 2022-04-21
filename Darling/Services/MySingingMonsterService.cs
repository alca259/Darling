namespace Darling.Services;

internal class MySingingMonsterService : IMySingingMonsterService
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ITesseractService _tesseractService;
    private readonly IImageService _imageService;
    private readonly ILogService _logService;

    private static IntPtr WindowHandler { get; set; }
    private static Process? GameProcess { get; set; }
    private static string? LastWindowTempPath { get; set; }
    private static Rectangle LastWindowRect { get; set; }
    private static Point LastWindowLocation => LastWindowRect.Location;

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
     * RecoverAllDiamonds <- void
     * NextIsland <- void
     * IsPaused <- bool
     * Play <- void
     */

    #region Public
    public async Task<bool> FindGameProcess()
    {
        if (IsProcessActive()) return true;

        (WindowHandler, GameProcess) = await ProcessHelper.FindProcess();

        if (!IsProcessActive())
        {
            WindowHandler = IntPtr.Zero;
            GameProcess = null;
            return false;
        }

        return true;
    }

    public async Task RecoverAllResources()
    {
        await CheckIfScreenIsClean();
        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetAll);
        if (click == null) return;

        await MouseHelper.LeftClick(click.Value);
        await CheckIfScreenIsClean();
    }

    public async Task NextIsland()
    {
        await CheckIfScreenIsClean();

        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMap);
        if (click == null) return;
        await MouseHelper.LeftClick(click.Value);
        await Task.Delay(300);

        click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapNext);
        if (click == null) return;
        await MouseHelper.LeftClick(click.Value);
        await Task.Delay(500);

        click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapGo);
        if (click == null) return;
        await MouseHelper.LeftClick(click.Value);
        await Task.Delay(1000);
    }


    #endregion

    /** Private **
     * IsProcessActive <- bool
     * GetActualPicturePath <- string?
     * GetMouseClickPosition <- Point?
     * CheckIfScreenIsClean <- void
     */

    #region Private
    private bool IsProcessActive()
    {
        return WindowHandler != IntPtr.Zero && !(GameProcess?.HasExited ?? true);
    }

    private async Task<string?> GetActualPicturePath()
    {
        if (!IsProcessActive()) return null;
        await WindowHelper.SetWindowToTopFront(WindowHandler);
        LastWindowRect = await WindowHelper.GetWindowRectangle(WindowHandler);
        var path = await WindowHelper.TakeScreenshot(LastWindowRect);
        LastWindowTempPath = path;
        return path;
    }

    private async Task<Point?> GetMouseClickPosition(string imgToSearchName)
    {
        if (!IsProcessActive()) return null;
        
        string? screenshotPath = await GetActualPicturePath();
        if (screenshotPath == null) return null;

        var imagePathToFind = Path.Combine(_hostEnvironment.ContentRootPath, imgToSearchName);
        (bool found, Point? btnCenter) = _imageService.FindImage(screenshotPath, imagePathToFind, AppConstants.ImageProcessing.ImageThreshold);

        if (!found || !btnCenter.HasValue) return null;

        Point btnPoint = btnCenter.Value;

        return new Point(LastWindowLocation.X + btnPoint.X, LastWindowLocation.Y + btnPoint.Y);
    }

    private async Task CheckIfScreenIsClean()
    {
        if (!IsProcessActive()) return;

        // Popup de publi?
        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonBannerPubli);
        if (click != null)
        {
            await MouseHelper.LeftClick(click.Value);
            return;
        }

        // Popup de todo recolectado?
        click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonBannerAllCollected);
        if (click != null)
        {
            await MouseHelper.LeftClick(click.Value);
            return;
        }

        // Está visible el botón de mapa?
        // No -> Hacer click en la esquina inferior izquierda + margen
        // Si -> Quiza no tenga botón de recolectar, no hacer nada
        click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMap);
        if (click == null)
        {
            await MouseHelper.LeftClick(new Point(LastWindowRect.Left + 100, LastWindowRect.Bottom - 10));
            return;
        }
    }

    private async Task<string?> ReadIslandText()
    {
        if (!IsProcessActive()) return null;

        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapGo);
        if (click == null) return null;

        // Tenemos el botón de ir, buscamos el texto superior

        var text = _tesseractService.GetStringFromImage(LastWindowTempPath, 0.8, 0.7, 1, 1);

        return null;
    }
    #endregion

    //
    //textBox1.Text = text + Environment.NewLine + textBox1.Text;
}
