using FlameDating.Constants;
using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Models;
using FlameDating.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlameDating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : BaseController
    {
        private readonly IChatService chatService;
        private readonly UserManager<User> userManager;

        public ChatController(IChatService _chatService,
            UserManager<User> userManager)
        {
            this.chatService = _chatService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("chats")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUsersChats()
        {
            var userId = GetUserId(HttpContext);

            var chats = await chatService.GetUsersChatsAsync(Guid.Parse(userId!));

            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                Message = "Successfully retrieved chats",
                Content = new
                {
                    chats = chats
                }
            });
        }

        [HttpGet]
        [Route("chat/{recieverId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetChatId(string recieverId)
        {
            if (IsIdValidGuidAndNotNull(recieverId) == false
               || await userManager.FindByIdAsync(recieverId) == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User not found"
                });
            }

            var senderId = GetUserId(HttpContext);

            if (senderId == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Not authorized"
                });
            }

            var chatId = await chatService.GetChatIdBySenderAndRecieverIds(Guid.Parse(senderId), Guid.Parse(recieverId));

            if (chatId == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Chat not found"
                });
            }

            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                Message = "Successfully retrieved chat id",
                Content = new
                {
                    chatId = chatId
                }
            });
        }
    }
}
