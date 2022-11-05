using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using Microsoft.Extensions.Options;

namespace Darling;

internal static class Program
{
    public static IHost AppHost { get; private set; }
    public static IServiceProvider ServiceProvider { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

        Log.Logger.Information("Application is started.");

        AppHost = CreateHostBuilder(args).Build();
        ServiceProvider = AppHost.Services;

        try
        {
            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            var options = ServiceProvider.GetRequiredService<IOptions<AppOptions>>();

            CultureInfo.CurrentCulture = new CultureInfo(options.Value.Language);
            CultureInfo.CurrentUICulture = new CultureInfo(options.Value.Language);

            mainForm.Title = $"{options.Value.Name} - {options.Value.Version}";
            AppHost.Run();
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
        })
        .ConfigureWinForms<MainForm>()
        .UseWinFormsLifetime()
        .UseConsoleLifetime();
}
