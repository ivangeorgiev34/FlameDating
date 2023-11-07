namespace FlameDating.Core.Contracts
{
    public interface IInterestService
    {
        Task CreateInterestsByIdsAsync(Guid userId, List<string> interestsIds);
    }
}
