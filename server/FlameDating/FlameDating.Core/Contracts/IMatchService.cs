namespace FlameDating.Core.Contracts
{
    public interface IMatchService
    {
        Task CreateMatchAsync(Guid firstUserId, Guid secondUserId);
    }
}
