using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Models;

namespace FlameDating.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepository repo;
        private readonly IChatService chatService;

        public MatchService(IRepository _repo,
            IChatService _chatService)
        {
            this.repo = _repo;
            this.chatService = _chatService;
        }

        public async Task CreateMatchAsync(Guid firstUserId, Guid secondUserId)
        {
            var chatId = await chatService.CreateChatAsync();

            var match = new Match()
            {
                FirstUserId = firstUserId,
                SecondUserId = secondUserId,
                ChatId = chatId,
                MatchDate = DateTime.Now
            };

            await repo.AddAsync(match);
            await repo.SaveChangesAsync();
        }
    }
}
