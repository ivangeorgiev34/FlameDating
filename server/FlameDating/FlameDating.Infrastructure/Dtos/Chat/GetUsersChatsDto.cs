using FlameDating.Infrastructure.Dtos.Account;

namespace FlameDating.Infrastructure.Dtos.Chat
{
    public class GetUsersChatsDto
    {
        public string Id { get; set; } = null!;

        public UserDto CurrentUser { get; set; } = null!;

        public UserDto RecipientUser { get; set; } = null!;
    }
}
