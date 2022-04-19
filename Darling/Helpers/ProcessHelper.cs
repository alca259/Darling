namespace Darling.Helpers;

internal static class ProcessHelper
{
    public static (IntPtr, IntPtr) FindProcess()
    {
        var activeProcess = Process.GetProcessesByName(MainForm.Constants.ProcessName);
        if (activeProcess == null || activeProcess.Length == 0) return (IntPtr.Zero, IntPtr.Zero);

        var process = activeProcess.First();

        return (process.MainWindowHandle, process.Handle);
    }
}
