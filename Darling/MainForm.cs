using Alca259.UIControls;
using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using Microsoft.Extensions.Options;

namespace Darling;

internal partial class MainForm : FlatForm, IWinFormsShell
{
    private readonly IMySingingMonsterService _monsterService;
    private readonly IOptionsMonitor<AppOptions> _optionsMonitor;
    private readonly System.Windows.Forms.Timer _timer;
    private static bool _isRunning = false;
    private static TimerActions _timerAction = TimerActions.CollectAll;
    private CancellationTokenSource _cancellationToken;

    public MainForm(
        IMySingingMonsterService monsterService,
        IOptionsMonitor<AppOptions> optionsMonitor)
    {
        InitializeComponent();
        _cancellationToken = new CancellationTokenSource();

        _monsterService = monsterService;
        _optionsMonitor = optionsMonitor;
        _timer = new System.Windows.Forms.Timer
        {
            Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds,
            Enabled = false
        };
        _timer.Tick += Timer_Tick;

        LogService.LogEvent += LogService_LogEvent;
        KeyManagementListenerBackground.StopRunningEvent += KeyManagementListenerBackground_StopRunningEvent;
    }

    private void KeyManagementListenerBackground_StopRunningEvent(object sender, KeyCap.Keyboard.KeyboardEventArgs e)
    {
        Invoke(() => StopActions());
    }

    private void LogService_LogEvent(object sender, string e)
    {
        LogTxtBox.PrependTextWithNewLine(e);
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (_isRunning) return;
        _isRunning = true;
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess(_cancellationToken.Token))
            {
                Invoke(() => StopActions());
                return;
            }

            switch (_timerAction)
            {
                case TimerActions.CollectAll:
                    if (switchMoney.Checked)
                    {
                        await _monsterService.RecoverAllResources(_cancellationToken.Token);
                        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DIAMONDS_WAIT), _cancellationToken.Token);
                    }

                    if (switchDiamonds.Checked)
                    {
                        await _monsterService.RecoverDiamonds(_cancellationToken.Token);
                        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DIAMONDS_WAIT), _cancellationToken.Token);
                    }

                    if (switchFood.Checked)
                    {
                        await _monsterService.RecoverFood(_cancellationToken.Token);
                        await _monsterService.RecoverFood(_cancellationToken.Token);
                        await _monsterService.RecoverFood(_cancellationToken.Token);
                        await _monsterService.RecoverFood(_cancellationToken.Token);
                        await _monsterService.RecoverFood(_cancellationToken.Token);
                    }

                    await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.ISLAND_STAY), _cancellationToken.Token);
                    await _monsterService.EnterNextIsland(_cancellationToken.Token);
                    await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.AFTER_ENTER_ISLAND), _cancellationToken.Token);
                    break;
                case TimerActions.VoteIsland:
                    if (switchVoteUp.Checked)
                    {
                        await _monsterService.VoteUpIsland(_cancellationToken.Token);
                        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.DIAMONDS_WAIT), _cancellationToken.Token);
                    }

                    if (switchFireTorch.Checked)
                    {
                        await _monsterService.FireTorch(_cancellationToken.Token);
                        await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.ISLAND_STAY), _cancellationToken.Token);
                    }

                    await _monsterService.NextVoteIsland(_cancellationToken.Token);
                    await Task.Delay(_optionsMonitor.CurrentValue.GetDelay(AppOptionsDelays.Keys.NEXT_VOTE_ISLAND), _cancellationToken.Token);
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
        StopActions();
    }

    private void BtnStartVote_Click(object sender, EventArgs e)
    {
        if (_timer.Enabled) return;
        _cancellationToken = new CancellationTokenSource();

        _timerAction = TimerActions.VoteIsland;
        _timer.Start();
        BtnStart.Enabled = false;
        BtnStop.Enabled = false;
        BtnStartVote.Enabled = false;
        BtnStopVote.Enabled = true;
    }

    private void BtnStopVote_Click(object sender, EventArgs e)
    {
        StopActions();
    }

    private void StopActions()
    {
        if (!_isRunning) return;
        _isRunning = false;

        BtnStart.Enabled = true;
        BtnStop.Enabled = false;
        BtnStartVote.Enabled = true;
        BtnStopVote.Enabled = false;

        _cancellationToken?.Cancel();
        if (_timer.Enabled) _timer.Stop();
    }
}
