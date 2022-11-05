namespace Darling.Services;

internal class LogService : ILogService
{
    private readonly ILogger<LogService> _logger;
    private const string LOG_FORMAT = "[{now}][App/{severity}] {message}";

    public static event EventHandler<string> LogEvent;

    public LogService(ILogger<LogService> logger)
    {
        _logger = logger;
    }

    public Task Log(string message, LogLevel severity = LogLevel.Debug)
    {
        var now = DateTime.Now;
        switch (severity)
        {
            case LogLevel.Critical:
                _logger.LogCritical(LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Error:
                _logger.LogError(LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Warning:
                _logger.LogWarning(LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Information:
                _logger.LogInformation(LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Trace:
                _logger.LogTrace(LOG_FORMAT, now, severity, message);
                break;
            default:
                _logger.LogDebug(LOG_FORMAT, now, severity, message);
                break;
        }

        var outputMessage = string.Format("[{0}][App/{1}] {2}", now, severity, message);
        if (Serilog.Log.Logger.IsEnabled((Serilog.Events.LogEventLevel)severity))
        {
            LogEvent?.Invoke(null, outputMessage);
        }

        Debug.WriteLine(outputMessage);
        return Task.CompletedTask;
    }

    public Task Log(Exception ex, string message, LogLevel severity = LogLevel.Debug)
    {
        var now = DateTime.Now;
        switch (severity)
        {
            case LogLevel.Critical:
                _logger.LogCritical(ex, LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Error:
                _logger.LogError(ex, LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Warning:
                _logger.LogWarning(ex, LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Information:
                _logger.LogInformation(LOG_FORMAT, now, severity, message);
                break;
            case LogLevel.Trace:
                _logger.LogTrace(LOG_FORMAT, now, severity, message);
                break;
            default:
                _logger.LogDebug(LOG_FORMAT, now, severity, message);
                break;
        }

        var outputMessage = string.Format("[{0}][App/{1}] {2}", now, severity, message);
        if (Serilog.Log.Logger.IsEnabled((Serilog.Events.LogEventLevel)severity))
        {
            LogEvent?.Invoke(null, outputMessage);
        }

        Debug.WriteLine(outputMessage);
        return Task.CompletedTask;
    }
}
