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

        _logService.Log("Application started", LogLevel.Information);
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

        await _logService.Log("FindGameProcess", LogLevel.Information);
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
        await _logService.Log("RecoverAllResources", LogLevel.Information);
        await CheckIfScreenIsClean();
        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetAll);
        if (click == null) return;

        await MouseHelper.LeftClick(click.Value);
        await CheckIfScreenIsClean();
    }

    public async Task NextIsland()
    {
        await _logService.Log("NextIsland", LogLevel.Information);
        await OpenMap();
        await NavigateNextIsland();

        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapGo);
        if (click == null) return;
        await MouseHelper.LeftClick(click.Value);
        await Task.Delay(1000);
    }

    public async Task OpenMap()
    {
        await _logService.Log("OpenMap", LogLevel.Information);
        await CheckIfScreenIsClean();

        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMap);
        if (click == null) return;
        await MouseHelper.LeftClick(click.Value);
        await Task.Delay(300);
    }

    public async Task NavigateNextIsland()
    {
        await _logService.Log("NavigateNextIsland", LogLevel.Information);
        var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapNext);
        if (click == null) return;
        await MouseHelper.LeftClick(click.Value);
        await Task.Delay(100);

        click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapOcupped, 0.60);

        if (click == null)
            click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapOcuppedSpecial1, 0.60);

        if (click == null)
        {
            await NavigateNextIsland();
            return;
        }

        await _logService.Log("Valid island found");

        //var textReaded = await ReadIslandText();
        //if (string.IsNullOrEmpty(textReaded)
        //    || !textReaded.Contains("camas", StringComparison.InvariantCultureIgnoreCase)
        //    || !textReaded.Contains("ocupada", StringComparison.InvariantCultureIgnoreCase))
        //{
        //    await _logService.Log($"Text not found or error: {textReaded}", LogLevel.Warning);
        //    await NavigateNextIsland();
        //    return;
        //}
        //await _logService.Log($"Text found: {textReaded}");
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

    private async Task<Point?> GetMouseClickPosition(string imgToSearchName, double threshold = AppConstants.ImageProcessing.ImageThreshold)
    {
        if (!IsProcessActive()) return null;
        
        string? screenshotPath = await GetActualPicturePath();
        if (screenshotPath == null) return null;

        var imagePathToFind = Path.Combine(_hostEnvironment.ContentRootPath, imgToSearchName);
        (bool found, Point? btnCenter) = _imageService.FindImage(screenshotPath, imagePathToFind, threshold);

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

    //private async Task<string?> ReadIslandText()
    //{
    //    if (!IsProcessActive()) return null;

    //    var click = await GetMouseClickPosition(AppConstants.ImageElements.ButtonGetMapGo);
    //    if (click == null) return null;

    //    /*
    //    X1 440px (550) / 1366 = 0.322 (0.402635)
    //    X2 980px (840) / 1366 = 0.717 (0.614934)
    //    Y1 575px (620) / 768  = 0.748 (0.807291)
    //    Y2 655px / 768  = 0.852864
    //    */
    //    // Tenemos el botón de ir, buscamos el texto superior
    //    double x1 = 0.402635;
    //    double x2 = 0.614934;
    //    double y1 = 0.807291;
    //    double y2 = 0.852864;

    //    var text = _tesseractService.GetStringFromImage(LastWindowTempPath, x1, y1, x2, y2);

    //    return text;
    //}
    #endregion

    //
    //textBox1.Text = text + Environment.NewLine + textBox1.Text;
}
