namespace Darling.Helpers;

internal static class ProcessHelper
{
    public static async Task<(IntPtr, Process?)> FindProcess()
    {
        var activeProcess = Process.GetProcessesByName(AppConstants.ProcessData.ProcessName);
        if (activeProcess == null || activeProcess.Length == 0) return (IntPtr.Zero, null);

        await Task.Delay(AppConstants.ProcessData.DelayThreadMilliseconds);
        var process = activeProcess.First();

        return (process.MainWindowHandle, process);
    }
}
