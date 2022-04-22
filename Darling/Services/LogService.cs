namespace Darling.Services;

internal class LogService : ILogService
{
    private readonly ILogger<LogService> _logger;

    public static event EventHandler<string>? LogEvent;

    public LogService(ILogger<LogService> logger)
    {
        _logger = logger;
    }

    public Task Log(string message, LogLevel severity = LogLevel.Debug)
    {
        if (!message.StartsWith('['))
        {
            message = $"[App/{severity}] {message}";
        }

        switch (severity)
        {
            case LogLevel.Critical:
                _logger.LogCritical(message);
                break;
            case LogLevel.Error:
                _logger.LogError(message);
                break;
            case LogLevel.Warning:
                _logger.LogWarning(message);
                break;
            case LogLevel.Information:
                _logger.LogInformation(message);
                break;
            case LogLevel.Trace:
                _logger.LogTrace(message);
                break;
            case LogLevel.Debug:
            default:
                _logger.LogDebug(message);
                break;
        }

        LogEvent?.Invoke(this, message);
        Debug.WriteLine(message);
        return Task.CompletedTask;
    }

    public Task Log(Exception ex, string message, LogLevel severity = LogLevel.Debug)
    {
        if (!message.StartsWith('['))
        {
            message = $"[App/{severity}] {message}";
        }

        switch (severity)
        {
            case LogLevel.Critical:
                _logger.LogCritical(ex, message);
                break;
            case LogLevel.Error:
                _logger.LogError(ex, message);
                break;
            case LogLevel.Warning:
                _logger.LogWarning(ex, message);
                break;
            case LogLevel.Information:
                _logger.LogInformation(message);
                break;
            case LogLevel.Trace:
                _logger.LogTrace(message);
                break;
            case LogLevel.Debug:
            default:
                _logger.LogDebug(message);
                break;
        }

        LogEvent?.Invoke(this, message);
        Debug.WriteLine(message);
        return Task.CompletedTask;
    }
}
