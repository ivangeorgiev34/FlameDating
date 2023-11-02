namespace FlameDating.Core.Contracts
{
    public interface IMessageService
    {
        Task AddMessageAsync(string text, Guid chatId, Guid senderId, Guid recieverId);
    }
}
