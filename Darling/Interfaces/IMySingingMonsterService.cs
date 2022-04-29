namespace Darling.Interfaces;

internal interface IMySingingMonsterService
{
    Task<bool> FindGameProcess();
    Task RecoverAllResources();
    Task RecoverDiamonds();
    Task EnterNextIsland();
    Task<bool> OpenMap();
    Task NavigateNextIsland();
}
