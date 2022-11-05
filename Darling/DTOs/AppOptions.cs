namespace Darling.DTOs;

public sealed class AppOptions
{
    public string ProcessName { get; set; }
    public string Language { get; set; }
    public string Version { get; set; }
    public string Name { get; set; }
    public double ThresholdButtons { get; set; }
    public double ThresholdMapIslandText { get; set; }
    public string TempImageFileName { get; set; }
    public List<AppOptionsDelays> DelayMilliseconds { get; set; } = new List<AppOptionsDelays>();

    /// <summary>
    /// Get delay for key, if not found, return 0, if less than 200, return 200.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public int GetDelay(string key)
    {
        var delay = DelayMilliseconds.FirstOrDefault(f => f.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
        int value = delay?.Value ?? 0;
        if (value <= 0)
        {
            value = DelayMilliseconds.First(f => f.Key.Equals(AppOptionsDelays.Keys.DEFAULT_WAIT_BETWEEN_ACTIONS, StringComparison.InvariantCultureIgnoreCase)).Value;
        }
        return value >= 200 ? value : 200;
    }
}

public sealed class AppOptionsDelays
{
    public struct Keys
    {
        public const string FIND_PROCESS = "FindProcess";
        public const string MOUSE_CLICK = "MouseClick";
        public const string WINDOW_TO_TOP = "WindowToTop";
        public const string DIAMONDS_WAIT = "DiamondsWait";
        public const string DEFAULT_WAIT_BETWEEN_ACTIONS = "DefaultWaitBetweenActions";
        public const string ISLAND_STAY = "IslandStay";
        public const string ISLAND_FIND_BUTTON = "IslandFindButton";
        public const string ISLAND_POPUP_WAIT = "IslandPopupWait";
        public const string NEXT_ISLAND = "NextIsland";
        public const string ENTER_ISLAND = "EnterIsland";
        public const string AFTER_ENTER_ISLAND = "AfterEnterIsland";
        public const string NEXT_VOTE_ISLAND = "NextVoteIsland";
    }

    public string Key { get; set; }
    /// <summary>
    /// Milliseconds
    /// </summary>
    public int Value { get; set; }

    public override string ToString()
    {
        return $"{Key}: {Value}";
    }
}
