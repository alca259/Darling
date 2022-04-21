namespace Darling;

internal partial class MainForm : Form
{
    private readonly IMySingingMonsterService _monsterService;

    public MainForm(
        IMySingingMonsterService monsterService)
    {
        InitializeComponent();
        _monsterService = monsterService;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(async () =>
        {
            if (!await _monsterService.FindGameProcess()) return;
            await _monsterService.RecoverAllResources();
        });
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }
}
