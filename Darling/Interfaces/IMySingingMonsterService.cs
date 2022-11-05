namespace Darling.Interfaces;

internal interface IMySingingMonsterService
{
    Task<bool> FindGameProcess(CancellationToken token);
    Task RecoverAllResources(CancellationToken token);
    Task RecoverDiamonds(CancellationToken token);
    Task<bool> RecoverFood(CancellationToken token);
    Task EnterNextIsland(CancellationToken token);
    Task<bool> OpenMap(CancellationToken token);
    Task NavigateNextIsland(CancellationToken token);
    Task VoteUpIsland(CancellationToken token);
    Task FireTorch(CancellationToken token);
    Task NextVoteIsland(CancellationToken token);
}
