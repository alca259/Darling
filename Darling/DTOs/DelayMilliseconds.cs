namespace Darling;

public struct DelayMilliseconds
{
    public DelayMilliseconds()
    {

    }

    [Range(200, 1000)] public int FindProcess { get; set; } = 300;
    [Range(100, 1000)] public int MouseClick { get; set; } = 300;
    [Range(100, 1000)] public int WindowToTop { get; set; } = 200;
    [Range(200, 1000)] public int DefaultWaitBetweenActions { get; set; } = 300;
    [Range(1000, 60000)] public int IslandStay { get; set; } = 1000;
    [Range(200, 1000)] public int IslandFindButton { get; set; } = 300;
    [Range(1000, 3000)] public int IslandPopupWait { get; set; } = 500;
    [Range(500, 1000)] public int NextIsland { get; set; } = 800;
    [Range(200, 1000)] public int EnterIsland { get; set; } = 800;
    [Range(1000, 5000)] public int AfterEnterIsland { get; set; } = 3000;
    [Range(1000, 5000)] public int MemoryGameWaitBetweenScreens { get; set; } = 1500;
    [Range(200, 2000)] public int MemoryGameDiscoverNext { get; set; } = 500;
}
