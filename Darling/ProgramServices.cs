namespace Darling;

internal static class ProgramServices
{
    public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton<MainForm>();
        services.AddSingleton<ILogService, LogService>();
        services.AddSingleton<ITesseractService, TesseractService>();
        services.AddSingleton<IImageService, ImageService>();
        services.AddSingleton<IMySingingMonsterService, MySingingMonsterService>();

        services.AddHostedService<KeyManagementListenerBackground>();

        services.Configure<AppOptions>(context.Configuration.GetSection(nameof(AppOptions)));
    }
}
