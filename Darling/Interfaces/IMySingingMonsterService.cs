namespace Darling.Interfaces;

internal interface IMySingingMonsterService
{
    Task<bool> FindGameProcess();
    Task RecoverAllResources();
    Task NextIsland();
    Task OpenMap();
    Task NavigateNextIsland();
}
