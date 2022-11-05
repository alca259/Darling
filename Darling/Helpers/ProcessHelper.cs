namespace Darling.Helpers;

internal static class ProcessHelper
{
    public static async Task<(IntPtr, Process)> FindProcess(AppOptions options, CancellationToken token)
    {
        var activeProcess = Process.GetProcessesByName(options.ProcessName);
        if (activeProcess == null || activeProcess.Length == 0) return (IntPtr.Zero, null);

        await Task.Delay(options.GetDelay(AppOptionsDelays.Keys.FIND_PROCESS), token);
        var process = activeProcess.First();

        return (process.MainWindowHandle, process);
    }
}
