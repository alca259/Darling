namespace Darling;

public class DelayMilliseconds
{
    public DelayMilliseconds()
    {

    }

    [Range(300, 1000)] public int FindProcess { get; set; } = 300;
    [Range(300, 1000)] public int MouseClick { get; set; } = 300;
    [Range(200, 1000)] public int WindowToTop { get; set; } = 200;
    [Range(300, 10000)] public int DiamondsWait { get; set; } = 1500;
    [Range(300, 1000)] public int DefaultWaitBetweenActions { get; set; } = 300;
    [Range(1000, 60000)] public int IslandStay { get; set; } = 1000;
    [Range(300, 1000)] public int IslandFindButton { get; set; } = 300;
    [Range(500, 3000)] public int IslandPopupWait { get; set; } = 500;
    [Range(800, 2000)] public int NextIsland { get; set; } = 800;
    [Range(800, 2000)] public int EnterIsland { get; set; } = 800;
    [Range(1000, 5000)] public int AfterEnterIsland { get; set; } = 3000;
    [Range(5000, 10000)] public int NextVoteIsland { get; set; } = 5000;
    [Range(1000, 5000)] public int MemoryGameWaitBetweenScreens { get; set; } = 1500;
    [Range(500, 2000)] public int MemoryGameDiscoverNext { get; set; } = 500;
}
