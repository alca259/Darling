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

    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            //await _monsterService.RecoverAllResources();
            await _monsterService.NextIsland();
        });
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (_timer.Enabled) return;
        _timer.Start();
    }
}
