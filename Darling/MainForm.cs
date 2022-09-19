using Alca259.Forms;
using Dapplo.Microsoft.Extensions.Hosting.WinForms;

namespace Darling;

internal partial class MainForm : FlatForm, IWinFormsShell
{
    private readonly IMySingingMonsterService _monsterService;
    private readonly System.Windows.Forms.Timer _timer;
    private static bool _isRunning = false;
    private CancellationTokenSource _cancellationToken;
    private static TimerActions _timerAction = TimerActions.CollectAll;

    public MainForm(
        IMySingingMonsterService monsterService)
    {
        InitializeComponent();
        _cancellationToken = new CancellationTokenSource();

        _monsterService = monsterService;
        _timer = new System.Windows.Forms.Timer
        {
            Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds,
            Enabled = false
        };
        _timer.Tick += Timer_Tick;

        LogService.LogEvent += LogService_LogEvent;
        KeyManagementListenerBackground.StopRunningEvent += KeyManagementListenerBackground_StopRunningEvent;

        AdjustUI();
    }

    private void KeyManagementListenerBackground_StopRunningEvent(object? sender, KeyCap.Keyboard.KeyboardEventArgs e)
    {
        if (!_isRunning) return;
        _isRunning = false;
        switch (_timerAction)
        {
            case TimerActions.CollectAll:
                BtnStop.ControlInvoke(() => BtnStop.PerformClick());
                break;
            case TimerActions.VoteIsland:
                BtnStopVote.ControlInvoke(() => BtnStopVote.PerformClick());
                break;
        }
    }

    private void AdjustUI()
    {
        sliderFindProcess.SetMilliseconds(AppSettings.Instance.Delays.FindProcess);
        sliderMouseClick.SetMilliseconds(AppSettings.Instance.Delays.MouseClick);
        sliderWindowToTop.SetMilliseconds(AppSettings.Instance.Delays.WindowToTop);
        sliderDiamondsWait.SetMilliseconds(AppSettings.Instance.Delays.DiamondsWait);
        sliderWaitBetweenActions.SetMilliseconds(AppSettings.Instance.Delays.DefaultWaitBetweenActions);
        sliderIslandStay.SetMilliseconds(AppSettings.Instance.Delays.IslandStay);
        sliderFindButton.SetMilliseconds(AppSettings.Instance.Delays.IslandFindButton);
        sliderPopupWait.SetMilliseconds(AppSettings.Instance.Delays.IslandPopupWait);
        sliderNextIsland.SetMilliseconds(AppSettings.Instance.Delays.NextIsland);
        sliderEnterIsland.SetMilliseconds(AppSettings.Instance.Delays.EnterIsland);
        sliderAfterEnterIsland.SetMilliseconds(AppSettings.Instance.Delays.AfterEnterIsland);
        sliderNextVoteIsland.SetMilliseconds(AppSettings.Instance.Delays.NextVoteIsland);
        sliderMemoryGameBetweenScenes.SetMilliseconds(AppSettings.Instance.Delays.MemoryGameWaitBetweenScreens);
        //sliderMemoryGameBetweenScenes.SetMilliseconds(AppSettings.Instance.Delays.MemoryGameDiscoverNext(milli));
        sliderThresholdButton.SetMilliseconds((int)Math.Truncate(AppSettings.Instance.ThresholdButtons * 100));
        sliderThresholdMapIsland.SetMilliseconds((int)Math.Truncate(AppSettings.Instance.ThresholdMapIslandText * 100));

        sliderFindProcess.SliderChanged += (e, milli) => AppSettings.Instance.Delays.FindProcess = milli;
        sliderMouseClick.SliderChanged += (e, milli) => AppSettings.Instance.Delays.MouseClick = milli;
        sliderWindowToTop.SliderChanged += (e, milli) => AppSettings.Instance.Delays.WindowToTop = milli;
        sliderDiamondsWait.SliderChanged += (e, milli) => AppSettings.Instance.Delays.DiamondsWait = milli;
        sliderWaitBetweenActions.SliderChanged += (e, milli) => AppSettings.Instance.Delays.DefaultWaitBetweenActions = milli;
        sliderIslandStay.SliderChanged += (e, milli) => AppSettings.Instance.Delays.IslandStay = milli;
        sliderFindButton.SliderChanged += (e, milli) => AppSettings.Instance.Delays.IslandFindButton = milli;
        sliderPopupWait.SliderChanged += (e, milli) => AppSettings.Instance.Delays.IslandPopupWait = milli;
        sliderNextIsland.SliderChanged += (e, milli) => AppSettings.Instance.Delays.NextIsland = milli;
        sliderEnterIsland.SliderChanged += (e, milli) => AppSettings.Instance.Delays.EnterIsland = milli;
        sliderAfterEnterIsland.SliderChanged += (e, milli) => AppSettings.Instance.Delays.AfterEnterIsland = milli;
        sliderNextVoteIsland.SliderChanged += (e, milli) => AppSettings.Instance.Delays.NextVoteIsland = milli;
        sliderMemoryGameBetweenScenes.SliderChanged += (e, milli) => AppSettings.Instance.Delays.MemoryGameWaitBetweenScreens = milli;
        //sliderMemoryGameBetweenScenes.SliderChanged += (e, milli) => AppSettings.Instance.Delays.MemoryGameDiscoverNext = milli;
        sliderThresholdButton.SliderChanged += (e, milli) => AppSettings.Instance.ThresholdButtons = milli / 100.0;
        sliderThresholdMapIsland.SliderChanged += (e, milli) => AppSettings.Instance.ThresholdMapIslandText = milli / 100.0;
    }

    private void LogService_LogEvent(object? sender, string e)
    {
        LogTxtBox.PrependTextWithNewLine(e);
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_isRunning) return;
        _isRunning = true;
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess(_cancellationToken.Token))
            {
                _isRunning = false;
                switch (_timerAction)
                {
                    case TimerActions.CollectAll:
                        BtnStop.ControlInvoke(() => BtnStop.PerformClick());
                        break;
                    case TimerActions.VoteIsland:
                        BtnStopVote.ControlInvoke(() => BtnStopVote.PerformClick());
                        break;
                }

                return;
            }

            switch (_timerAction)
            {
                case TimerActions.CollectAll:
                    await _monsterService.RecoverAllResources(_cancellationToken.Token);
                    await Task.Delay(AppSettings.Instance.Delays.DiamondsWait, _cancellationToken.Token);
                    await _monsterService.RecoverDiamonds(_cancellationToken.Token);
                    await Task.Delay(AppSettings.Instance.Delays.IslandStay, _cancellationToken.Token);
                    await _monsterService.EnterNextIsland(_cancellationToken.Token);
                    await Task.Delay(AppSettings.Instance.Delays.AfterEnterIsland, _cancellationToken.Token);
                    break;
                case TimerActions.VoteIsland:
                    await _monsterService.VoteUpIsland(_cancellationToken.Token);
                    await Task.Delay(AppSettings.Instance.Delays.DiamondsWait, _cancellationToken.Token);
                    await _monsterService.FireTorch(_cancellationToken.Token);
                    await Task.Delay(AppSettings.Instance.Delays.IslandStay, _cancellationToken.Token);
                    await _monsterService.NextVoteIsland(_cancellationToken.Token);
                    await Task.Delay(AppSettings.Instance.Delays.NextVoteIsland, _cancellationToken.Token);
                    break;
            }

            _isRunning = false;
        });
    }

    private void BtnStart_Click(object sender, EventArgs e)
    {
        if (_timer.Enabled) return;
        _cancellationToken = new CancellationTokenSource();

        _timerAction = TimerActions.CollectAll;
        _timer.Start();
        BtnStart.Enabled = false;
        BtnStop.Enabled = true;
        BtnStartVote.Enabled = false;
        BtnStopVote.Enabled = false;
    }

    private void BtnStop_Click(object sender, EventArgs e)
    {
        if (!_timer.Enabled) return;
        _timer.Stop();
        BtnStart.Enabled = true;
        BtnStop.Enabled = false;
        BtnStartVote.Enabled = true;
        BtnStopVote.Enabled = false;
    }

    private void BtnStartVote_Click(object sender, EventArgs e)
    {
        if (_timer.Enabled) return;
        _timerAction = TimerActions.VoteIsland;
        _timer.Start();
        BtnStart.Enabled = false;
        BtnStop.Enabled = false;
        BtnStartVote.Enabled = false;
        BtnStopVote.Enabled = true;
    }

    private void BtnStopVote_Click(object sender, EventArgs e)
    {
        if (!_timer.Enabled) return;
        _timer.Stop();
        BtnStart.Enabled = true;
        BtnStop.Enabled = false;
        BtnStartVote.Enabled = true;
        BtnStopVote.Enabled = false;
    }
}
