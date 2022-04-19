namespace Darling;

internal static class Program
{
    public static IHost? AppHost { get; private set; }
    public static IServiceProvider? ServiceProvider { get; private set; }
    private const string AppLanguage = "es-ES";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        CultureInfo.CurrentCulture = new CultureInfo(AppLanguage);
        CultureInfo.CurrentUICulture = new CultureInfo(AppLanguage);

        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

        Log.Logger.Information("Application is started.");

        AppHost = CreateHostBuilder(args).Build();
        ServiceProvider = AppHost.Services;

        try
        {
            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            Log.Logger.Information("Aplication is closed. " + ex.Message);
        }
    }


    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .UseContentRoot(Directory.GetCurrentDirectory())
        .ConfigureAppConfiguration((context, builder) =>
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true);
            builder.AddEnvironmentVariables();
        })
        .ConfigureServices((context, services) => ProgramServices.ConfigureServices(context, services))
        .ConfigureLogging(logging =>
        {
            // Borramos todos los registros de los loggers que vienen prerregistrados
            logging.ClearProviders();
        })
        .UseSerilog((HostBuilderContext context, LoggerConfiguration loggerConfiguration) =>
        {
            // Añadimos Serilog obteniendo la configuración desde Microsoft.Extensions.Configuration
            loggerConfiguration.ReadFrom.Configuration(context.Configuration);
        });
}
