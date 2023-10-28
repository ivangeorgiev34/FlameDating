namespace FlameDating.Core.Contracts
{
    public interface IChatService
    {
        Task<Guid> CreateChatAsync();
    }
}
