using FlameDating.Constants;
using FlameDating.Core.Contracts;
using FlameDating.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlameDating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : BaseController
    {
        private readonly IChatService chatService;

        public ChatController(IChatService _chatService)
        {
            this.chatService = _chatService;
        }

        [HttpGet]
        [Route("/chats")]
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
    }
}
