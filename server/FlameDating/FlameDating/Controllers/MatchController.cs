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
    public class MatchController : BaseController
    {
        private readonly IMatchService matchService;

        public MatchController(IMatchService _matchService)
        {
            this.matchService = _matchService;
        }

        [HttpGet]
        [Route("matches")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SuggestMatches()
        {
            var userId = GetUserId(this.HttpContext);

            try
            {
                var suggestedMatches = await matchService.GetUserSuggestedMatchesByIdAsync(Guid.Parse(userId!));

                return StatusCode(StatusCodes.Status200OK, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                    Message = "Suggested matches retrieved successfully",
                    Content = new
                    {
                        matches = suggestedMatches
                    }
                });
            }
            catch (NullReferenceException nre)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = nre.Message
                });
            }
        }
    }
}
