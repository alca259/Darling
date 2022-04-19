namespace Darling.Interfaces;

internal interface ILogService
{
    Task Log(string message, LogLevel severity = LogLevel.Debug);
    Task Log(Exception ex, string message, LogLevel severity = LogLevel.Debug);
}
