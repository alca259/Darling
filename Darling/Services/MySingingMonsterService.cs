using Microsoft.Extensions.Options;

namespace Darling.Services;

internal class MySingingMonsterService : IMySingingMonsterService
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly IImageService _imageService;
    private readonly ILogService _logService;
    private readonly IOptionsMonitor<AppOptions> _optionsMonitor;

    public MySingingMonsterService(
        IHostEnvironment hostEnvironment,
        IImageService imageService,
        ILogService logService,
        IOptionsMonitor<AppOptions> optionsMonitor)
    {
        _hostEnvironment = hostEnvironment;
        _imageService = imageService;
        _logService = logService;
        _optionsMonitor = optionsMonitor;
        _logService.Log("Application started", LogLevel.Information);
    }

    #region Public
    public async Task<bool> FindGameProcess(CancellationToken token)
    {
        if (AppInstance.Instance.CurrentProcess.IsProcessActive()) return true;

        await _logService.Log("FindGameProcess");
        AppInstance.Instance.CurrentProcess.SetHandlerProcess(await ProcessHelper.FindProcess(_optionsMonitor.CurrentValue, token));

        if (AppInstance.Instance.CurrentProcess.IsProcessActive()) return true;

        AppInstance.Instance.CurrentProcess.ClearProcess();
        return false;
    }

    public async Task RecoverAllResources(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("RecoverAllResources");

        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetAll, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.ISLAND_POPUP_WAIT), token);

        await TakePicture(token);

        // Popup de OK?
        found = FindSubImage(AppConstants.ImageElements.ButtonBannerOk, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (found)
        {
            await MouseHelper.LeftClick(token: token);
            await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.ISLAND_FIND_BUTTON), token);
        }
    }

    public async Task RecoverDiamonds(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("RecoverDiamonds");
        
        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetDiamond, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
    }

    public async Task<bool> RecoverFood(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return false;
        await _logService.Log("RecoverFood");

        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetFood, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return false;

        await MouseHelper.LeftClick(token: token);
        return true;
    }

    public async Task EnterNextIsland(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;

        await _logService.Log("EnterNextIsland");
        if (!await OpenMap(token))
        {
            await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DEFAULT_WAIT_BETWEEN_ACTIONS), token);
            if (!await OpenMap(token)) return;
        }

        await NavigateNextIsland(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMapGo, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.ENTER_ISLAND), token);
    }

    public async Task<bool> OpenMap(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return false;

        await _logService.Log("OpenMap");
        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMap, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return false;

        await MouseHelper.LeftClick(token: token);
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DEFAULT_WAIT_BETWEEN_ACTIONS), token);

        return true;
    }

    public async Task NavigateNextIsland(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;

        await _logService.Log("NavigateNextIsland");
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.NEXT_ISLAND), token);
        await TakePicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonGetMapNext, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.MOUSE_CLICK), token);

        await TakePicture(token);
        found = FindSubImage(AppConstants.ImageElements.ButtonGetMapOcupped, _optionsMonitor.CurrentValue.ThresholdMapIslandText);

        if (!found)
        {
            found = FindSubImage(AppConstants.ImageElements.ButtonGetMapOcuppedSpecial1, _optionsMonitor.CurrentValue.ThresholdMapIslandText);
        }

        if (!found)
        {
            found = FindSubImage(AppConstants.ImageElements.ButtonGetMapOcuppedSpecial2, _optionsMonitor.CurrentValue.ThresholdMapIslandText);
        }

        if (!found)
        {
            await NavigateNextIsland(token);
        }
    }

    #endregion

    #region Vote Island public
    public async Task VoteUpIsland(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("VoteUpIsland");

        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonVoteIslandUp, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DEFAULT_WAIT_BETWEEN_ACTIONS), token);

    }

    public async Task FireTorch(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("FireTorch");

        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonVoteIslandTorchOn, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
    }

    public async Task NextVoteIsland(CancellationToken token)
    {
        if (!AppInstance.Instance.CurrentProcess.IsProcessActive()) return;
        await _logService.Log("NextVoteIsland");

        await TakeCleanPicture(token);

        var found = FindSubImage(AppConstants.ImageElements.ButtonVoteIslandNext, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found) return;

        await MouseHelper.LeftClick(token: token);
        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DEFAULT_WAIT_BETWEEN_ACTIONS), token);
    }
    #endregion

    #region Private
    private async Task TakeCleanPicture(CancellationToken token)
    {
        await TakePicture(token);
        bool isClean = await CheckIfScreenIsClean(token);
        if (!isClean) await TakePicture(token);
    }

    private async Task TakePicture(CancellationToken token)
    {
        await WindowHelper.SetWindowToTopFront(_optionsMonitor.CurrentValue, token);
        WindowHelper.GetWindowRectangle();
        WindowHelper.TakeScreenshot(_optionsMonitor.CurrentValue);
    }

    private bool FindSubImage(string imgToSearchName, double threshold)
    {
        var imagePathToFind = Path.Combine(_hostEnvironment.ContentRootPath, imgToSearchName);
        (bool found, Point btnCenter) = _imageService.FindImage(AppInstance.Instance.CurrentProcess.CapturePath, imagePathToFind, threshold);

        if (!found) return false;

        AppInstance.Instance.CurrentProcess.SetClickPoint(btnCenter);
        return true;
    }

    private async Task<bool> CheckIfScreenIsClean(CancellationToken token)
    {
        // Popup de publi?
        bool found = FindSubImage(AppConstants.ImageElements.ButtonBannerPubli, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (found)
        {
            await _logService.Log("Banner detected, closing...");
            await MouseHelper.LeftClick(token: token);
            return false;
        }

        // Popup de OK?
        found = FindSubImage(AppConstants.ImageElements.ButtonBannerOk, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (found)
        {
            await MouseHelper.LeftClick(token: token);
            return false;
        }

        // Está visible el botón de mapa?
        // No -> Hacer click en la esquina inferior izquierda + margen
        // Si -> Quiza no tenga botón de recolectar, no hacer nada
        found = FindSubImage(AppConstants.ImageElements.ButtonGetMap, _optionsMonitor.CurrentValue.ThresholdButtons);
        if (!found)
        {
            await MouseHelper.LeftClick(AppInstance.Instance.CurrentProcess.RightBottomPoint, token);
            return false;
        }

        return true;
    }
    #endregion
}
