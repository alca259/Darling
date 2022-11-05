namespace Darling;

public class AppInstance
{
    private static AppInstance? _instance;
    public static AppInstance Instance => _instance ??= new AppInstance();

    private AppInstance()
    {

    }

    public AppProcessInfo CurrentProcess { get; set; } = new AppProcessInfo();
}
