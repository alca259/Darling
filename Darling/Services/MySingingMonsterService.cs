namespace Darling.Services;

internal class MySingingMonsterService : IMySingingMonsterService
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ITesseractService _tesseractService;
    private readonly IImageService _imageService;
    private readonly ILogService _logService;

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

    #region Public
    public async Task<bool> FindGameProcess()
    {
        if (AppSettings.Instance.CurrentProcess.IsProcessActive()) return true;

        await _logService.Log("FindGameProcess");
        AppSettings.Instance.CurrentProcess.SetHandlerProcess(await ProcessHelper.FindProcess());

        if (AppSettings.Instance.CurrentProcess.IsProcessActive()) return true;

        AppSettings.Instance.CurrentProcess.ClearProcess();
        return false;
    }

    public async Task RecoverAllResources()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("RecoverAllResources");

        await TakeCleanPicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetAll, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
        await Task.Delay(AppSettings.Instance.Delays.IslandPopupWait);

        await TakePicture();

        // Popup de OK?
        found = FindSubImage(AppConstants.ImageElements.ButtonBannerOk, AppSettings.Instance.ThresholdButtons);
        if (found)
        {
            await MouseHelper.LeftClick();
            await Task.Delay(AppSettings.Instance.Delays.IslandFindButton);
            return;
        }
    }

    public async Task RecoverDiamonds()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("RecoverDiamonds");
        
        await TakeCleanPicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetDiamond, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
    }

    public async Task EnterNextIsland()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;

        await _logService.Log("EnterNextIsland");
        if (!await OpenMap())
        {
            await Task.Delay(AppSettings.Instance.Delays.DefaultWaitBetweenActions);
            if (!await OpenMap()) return;
        }

        await NavigateNextIsland();

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMapGo, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
        await Task.Delay(AppSettings.Instance.Delays.EnterIsland);
    }

    public async Task<bool> OpenMap()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return false;

        await _logService.Log("OpenMap");
        await TakeCleanPicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMap, AppSettings.Instance.ThresholdButtons);
        if (!found) return false;

        await MouseHelper.LeftClick();
        await Task.Delay(AppSettings.Instance.Delays.DefaultWaitBetweenActions);

        return true;
    }

    public async Task NavigateNextIsland()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;

        await _logService.Log("NavigateNextIsland");
        await Task.Delay(AppSettings.Instance.Delays.NextIsland);
        await TakePicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMapNext, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
        await Task.Delay(AppSettings.Instance.Delays.MouseClick);

        await TakePicture();
        found = FindSubImage(AppConstants.ImageElements.ButtonGetMapOcupped, AppSettings.Instance.ThresholdMapIslandText);

        if (!found)
        {
            found = FindSubImage(AppConstants.ImageElements.ButtonGetMapOcuppedSpecial1, AppSettings.Instance.ThresholdMapIslandText);
        }

        if (!found)
        {
            await NavigateNextIsland();
            return;
        }

        //var textReaded = ReadIslandText();
        //if (!string.IsNullOrEmpty(textReaded))
        //{
        //    await _logService.Log($"Valid island found: (({textReaded}))");
        //}
    }

    #endregion

    #region Vote Island public
    public async Task VoteUpIsland()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("VoteUpIsland");

        await TakeCleanPicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonVoteIslandUp, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
        await Task.Delay(AppSettings.Instance.Delays.DefaultWaitBetweenActions);

    }

    public async Task FireTorch()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("FireTorch");

        await TakeCleanPicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonVoteIslandTorchOn, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
    }

    public async Task NextVoteIsland()
    {
        if (!AppSettings.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("NextVoteIsland");

        await TakeCleanPicture();

        var found = FindSubImage(AppConstants.ImageElements.ButtonVoteIslandNext, AppSettings.Instance.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick();
        await Task.Delay(AppSettings.Instance.Delays.DefaultWaitBetweenActions);
    }
    #endregion

    #region Private
    private async Task TakeCleanPicture()
    {
        await TakePicture();
        bool isClean = await CheckIfScreenIsClean();
        if (!isClean) await TakePicture();
    }

    private async Task TakePicture()
    {
        await WindowHelper.SetWindowToTopFront();
        WindowHelper.GetWindowRectangle();
        WindowHelper.TakeScreenshot();
    }

    private bool FindSubImage(string imgToSearchName, double threshold)
    {
        var imagePathToFind = Path.Combine(_hostEnvironment.ContentRootPath, imgToSearchName);
        (bool found, Point btnCenter) = _imageService.FindImage(AppSettings.Instance.CurrentProcess.CapturePath, imagePathToFind, threshold);

        if (!found) return false;

        AppSettings.Instance.CurrentProcess.SetClickPoint(btnCenter);
        return true;
    }

    private async Task<bool> CheckIfScreenIsClean()
    {
        // Popup de publi?
        bool found = FindSubImage(AppConstants.ImageElements.ButtonBannerPubli, AppSettings.Instance.ThresholdButtons);
        if (found)
        {
            await _logService.Log("Banner detected, closing...");
            await MouseHelper.LeftClick();
            return false;
        }

        // Popup de OK?
        found = FindSubImage(AppConstants.ImageElements.ButtonBannerOk, AppSettings.Instance.ThresholdButtons);
        if (found)
        {
            await MouseHelper.LeftClick();
            return false;
        }

        // Está visible el botón de mapa?
        // No -> Hacer click en la esquina inferior izquierda + margen
        // Si -> Quiza no tenga botón de recolectar, no hacer nada
        found = FindSubImage(AppConstants.ImageElements.ButtonGetMap, AppSettings.Instance.ThresholdButtons);
        if (!found)
        {
            await MouseHelper.LeftClick(AppSettings.Instance.CurrentProcess.RightBottomPoint);
            return false;
        }

        return true;
    }

    private string? ReadIslandText()
    {
        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMapGo, AppSettings.Instance.ThresholdButtons);
        if (!found) return null;

        /*
         * Camas ocupadas
         *  X1 550 / 1366 = 0.402635
         *  X2 840 / 1366 = 0.614934
         *  Y1 620 / 768  = 0.807291
         *  Y2 655 / 768  = 0.852864
        */
        /*
         * Nombre de isla
         *  X1 440 / 1366 = 0.322108345534407
         *  X2 925 / 1366 = 0.677159590043923
         *  Y1 575 / 768  = 0.748697916666667
         *  Y2 620 / 768  = 0.807291666666667
         */

        // Buscamos el texto en la franja proporcional indicada
        double x1 = 0.322108345534407;
        double x2 = 0.677159590043923;
        double y1 = 0.748697916666667;
        double y2 = 0.807291666666667;

        var text = _tesseractService.GetStringFromImage(AppSettings.Instance.CurrentProcess.CapturePath, x1, y1, x2, y2);

        return text;
    }
    #endregion
}
