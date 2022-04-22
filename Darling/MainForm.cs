namespace Darling;

internal partial class MainForm : Form
{
    private readonly IMySingingMonsterService _monsterService;
    private readonly System.Windows.Forms.Timer _timer;
    private static bool _isRunning = false;

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
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.RecoverAllResources();
            await Task.Delay(1000);
            await _monsterService.NextIsland();
            await Task.Delay(4000);
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
            // TODO: Pick diamonds
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
            await _monsterService.NextIsland();
        });
    }

    private void BtnOpenMapAndNext_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.NextIsland();
        });
    }

    private void BtnStart_Click(object sender, EventArgs e)
    {
        if (_timer.Enabled) return;
        _timer.Start();
    }

    private void BtnStop_Click(object sender, EventArgs e)
    {
        if (!_timer.Enabled) return;
        _timer.Stop();
    }
}
