﻿namespace Darling.Helpers;

internal static class ProcessHelper
{
    public static async Task<(IntPtr, Process?)> FindProcess(CancellationToken token)
    {
        var activeProcess = Process.GetProcessesByName(AppSettings.Instance.ProcessName);
        if (activeProcess == null || activeProcess.Length == 0) return (IntPtr.Zero, null);

        await Task.Delay(AppSettings.Instance.Delays.FindProcess, token);
        var process = activeProcess.First();

        return (process.MainWindowHandle, process);
    }
}
