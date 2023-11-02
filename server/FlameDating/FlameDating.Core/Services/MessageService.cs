using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository repo;

        public MessageService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task AddMessageAsync(string text, Guid chatId, Guid senderId, Guid recieverId)
        {
            var chat = await repo.All<Chat>()
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == chatId);

            if (chat == null)
            {
                throw new NullReferenceException("Chat does not exist");
            }

            var message = new Message()
            {
                Text = text,
                Date = DateTime.Now,
                RecieverUserId = recieverId,
                SenderUserId = senderId
            };

            chat.Messages.Add(message);

            await repo.SaveChangesAsync();
        }
    }
}
