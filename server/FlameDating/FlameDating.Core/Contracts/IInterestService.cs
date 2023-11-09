using FlameDating.Infrastructure.Dtos.Interest;

namespace FlameDating.Core.Contracts
{
    public interface IInterestService
    {
        Task CreateInterestsByIdsAsync(Guid userId, List<string> interestsIds);

        Task<IEnumerable<InterestDto>> GetAllInterestsAsync();
    }
}
