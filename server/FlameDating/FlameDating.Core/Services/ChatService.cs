using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Models;

namespace FlameDating.Core.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository repo;

        public ChatService(IRepository _repo)
        {
            this.repo = _repo;
        }
        public async Task<Guid> CreateChatAsync()
        {
            var chat = new Chat();

            await repo.AddAsync(chat);
            await repo.SaveChangesAsync();

            return chat.Id;
        }
    }
}
