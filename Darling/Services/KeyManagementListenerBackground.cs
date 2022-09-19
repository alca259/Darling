using KeyCap.Keyboard;

namespace Darling.Services;

internal class KeyManagementListenerBackground : IHostedService
{
    private readonly ILogService _logService;
    private readonly IHostApplicationLifetime _appLifetime;

    public static event EventHandler<KeyboardEventArgs>? StopRunningEvent;

    public KeyManagementListenerBackground(
        ILogService logService,
        IHostApplicationLifetime appLifetime)
    {
        _logService = logService;
        _appLifetime = appLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _appLifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(async () =>
            {
                try
                {
                    KeyListenerApp keyListener = new KeyListenerApp(null);
                    keyListener.KeyEvent += KeyListener_KeyEvent;
                    keyListener.Start();

                    // Simulate real work is being done
                    await Task.Delay(1000);
                }
                catch (Exception ex)
                {
                    await _logService.Log(ex, "Unhandled exception!");
                }
                finally
                {
                    // Stop the application once the work is done
                    _appLifetime.StopApplication();
                }
            });
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void KeyListener_KeyEvent(object? sender, KeyboardEventArgs e)
    {
        if (e.KeyboardState.Ctrl && e.EventKeyCode == KeyCap.Keys.F7)
        {
            StopRunningEvent?.Invoke(this, e);
        }

        // Stop propagation
        e.Handled = true;
        return;

        //All the relevant info of the event

        //Key press/hold/release, and the key itself
        //Debug.WriteLine($"{e.EventType}");
        //Debug.WriteLine($"{e.EventKeyCode}");
        //Debug.WriteLine($"{e.ScanCode}");

        //If this event generates character input, you can also do this
        //if (e.IsCharInput)
        //{
        //    Debug.WriteLine(e.Characters);
        //}

        ////All the modifier keys
        //Debug.WriteLine("Shift: {0}", e.KeyboardState.Shift);
        //Debug.WriteLine("Ctrl: {0}", e.KeyboardState.Ctrl);
        //Debug.WriteLine("Alt: {0}", e.KeyboardState.Alt);
        //Debug.WriteLine("Win: {0}", e.KeyboardState.Win);
    }
}
