using FlameDating.Core.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Net.WebSockets;

namespace FlameDating.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub : Hub
    {
        private readonly IMessageService messageService;

        public ChatHub(IMessageService _messageService)
        {
            this.messageService = _messageService;
        }

        public async Task SendMessageAsync(string text, string chatId, string recieverId)
        {
            var senderId = this.Context.UserIdentifier;

            await messageService.AddMessageAsync(text, Guid.Parse(chatId), Guid.Parse(senderId),
                Guid.Parse(recieverId));

            await this.Clients.User(recieverId.ToLower())
                .SendAsync("RecieveMessage", senderId, text);
        }
    }
}

