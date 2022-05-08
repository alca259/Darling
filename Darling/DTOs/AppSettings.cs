namespace Darling;

public class AppSettings
{
    private static AppSettings? _instance;
    public static AppSettings Instance => _instance ??= new AppSettings();

    private AppSettings()
    {

    }

    public DelayMilliseconds Delays { get; set; } = new DelayMilliseconds();
    public AppProcessInfo CurrentProcess { get; set; } = new AppProcessInfo();
    [Range(0.01, 0.99)] public double ThresholdButtons { get; set; } = 0.85;
    [Range(0.01, 0.99)] public double ThresholdMapIslandText { get; set; } = 0.60;
    public string ProcessName { get; set; } = "MySingingMonsters";
    public string Language { get; set; } = "es-ES";
    public string Version { get; set; } = "1.0.1";
    public string Name { get; set; } = "Darling";
    public string TempImageFileName { get; set; } = "AlcaTempFile.jpg";
}
