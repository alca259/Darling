namespace Darling;

internal partial class MainForm : Form
{
    private readonly IMySingingMonsterService _monsterService;
    private readonly System.Windows.Forms.Timer _timer;
    private static bool _isRunning = false;
    private static TimerActions _timerAction = TimerActions.CollectAll;

    public MainForm(
        IMySingingMonsterService monsterService)
    {
        InitializeComponent();
        _monsterService = monsterService;
        _timer = new System.Windows.Forms.Timer
        {
            Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds,
            Enabled = false
        };
        _timer.Tick += Timer_Tick;

        LogService.LogEvent += LogService_LogEvent;
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
            if (!await _monsterService.FindGameProcess())
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
                    await _monsterService.RecoverAllResources();
                    await Task.Delay(AppSettings.Instance.Delays.DefaultWaitBetweenActions);
                    await _monsterService.RecoverDiamonds();
                    await Task.Delay(AppSettings.Instance.Delays.IslandStay);
                    await _monsterService.EnterNextIsland();
                    await Task.Delay(AppSettings.Instance.Delays.AfterEnterIsland);
                    break;
                case TimerActions.VoteIsland:
                    await _monsterService.VoteUpIsland();
                    await Task.Delay(AppSettings.Instance.Delays.DefaultWaitBetweenActions);
                    await _monsterService.FireTorch();
                    await Task.Delay(AppSettings.Instance.Delays.IslandStay);
                    await _monsterService.NextVoteIsland();
                    await Task.Delay(AppSettings.Instance.Delays.NextVoteIsland);
                    break;
            }

            _isRunning = false;
        });
    }

    private void BtnPickAll_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.RecoverAllResources();
        });
    }

    private void BtnPickDiamonds_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.RecoverDiamonds();
        });
    }

    private void BtnOpenMap_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.OpenMap();
        });
    }

    private void BtnNextIsland_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.NavigateNextIsland();
        });
    }

    private void BtnCompletePath_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.RecoverAllResources();
            await _monsterService.EnterNextIsland();
        });
    }

    private void BtnOpenMapAndNext_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.EnterNextIsland();
        });
    }

    private void BtnStart_Click(object sender, EventArgs e)
    {
        if (_timer.Enabled) return;
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
