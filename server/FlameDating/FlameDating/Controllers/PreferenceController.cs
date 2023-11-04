using FlameDating.Constants;
using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Dtos.Preference;
using FlameDating.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlameDating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : BaseController
    {
        private readonly IPreferenceService preferenceService;
        private readonly IAccountService accountService;

        public PreferenceController(IPreferenceService _preferenceService,
             IAccountService _accountService)
        {
            this.preferenceService = _preferenceService;
            this.accountService = _accountService;
        }

        [HttpPut]
        [Route("/edit/{preferenceId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditPreference(string preferenceId, PreferenceDto preferenceDto)
        {
            if (IsIdValidGuidAndNotNull(preferenceId) == false
                || await preferenceService.PreferenceExistsByIdAsync(Guid.Parse(preferenceId)) == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Preference does not exist"
                });
            }

            var userId = GetUserId(this.HttpContext);

            if (await accountService
                .UserHasPreferenceByIdAsync(Guid.Parse(userId!), Guid.Parse(preferenceId)) == false)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Cannot edit preference you do not own"
                });
            }

            try
            {
                await preferenceService.EditPreferenceByIdAsync(Guid.Parse(preferenceId), preferenceDto.MaximumDistance, preferenceDto.Gender);

                return StatusCode(StatusCodes.Status201Created, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Preference edited successfully"
                });
            }
            catch (NullReferenceException nre)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = nre.Message
                });
            }

        }
    }
}
