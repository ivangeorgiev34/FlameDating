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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LikeController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly ILikeService likeService;

        public LikeController(UserManager<User> _userManager,
            ILikeService _likeService)
        {
            this.userManager = _userManager;
            this.likeService = _likeService;
        }
        [HttpPost]
        [Route("like/{likedUserId}")]
        public async Task<IActionResult> LikeUser(string likedUserId)
        {
            if (IsIdValidGuidAndNotNull(likedUserId) == false
                || await userManager.FindByIdAsync(likedUserId) == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User not found"
                });
            }

            var likerUserId = GetUserId(HttpContext);

            if (Guid.Parse(likerUserId!) == Guid.Parse(likedUserId))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User cannot like himself"
                });
            }

            try
            {
                var didUsersMatch = await likeService.LikeUserAsync(Guid.Parse(likerUserId!), Guid.Parse(likedUserId));

                if (didUsersMatch == true)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response
                    {
                        Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                        Message = "Successfully matched with user"
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                    Message = "Successfully liked user"
                });
            }
            catch (InvalidOperationException ioe)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = ioe.Message
                });
            }
        }
    }
}
