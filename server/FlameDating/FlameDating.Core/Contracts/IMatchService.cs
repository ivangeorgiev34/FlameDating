using FlameDating.Infrastructure.Dtos.Account;

namespace FlameDating.Core.Contracts
{
    public interface IMatchService
    {
        Task CreateMatchAsync(Guid firstUserId, Guid secondUserId);

        Task<bool> MatchExistsAsync(Guid firstUserId, Guid secondUserId);

        Task<List<UserDto>> GetUserSuggestedMatchesByIdAsync(Guid userId);
    }
}
