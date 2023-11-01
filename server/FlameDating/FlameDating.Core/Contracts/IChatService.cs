using FlameDating.Infrastructure.Dtos.Chat;

namespace FlameDating.Core.Contracts
{
    public interface IChatService
    {
        Task<Guid> CreateChatAsync();

        Task<List<GetUsersChatsDto>> GetUsersChatsAsync(Guid userId);
    }
}
