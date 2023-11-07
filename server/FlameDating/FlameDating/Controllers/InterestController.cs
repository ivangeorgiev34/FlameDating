using FlameDating.Constants;
using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Dtos.Interest;
using FlameDating.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlameDating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : BaseController
    {
        private readonly IInterestService interestService;

        public InterestController(IInterestService _interestService)
        {
            this.interestService = _interestService;
        }

        [HttpPost]
        [Route("interests")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateInterests(CreateInterestsDto createInterestsDto)
        {
            var userId = GetUserId(this.HttpContext);

            var doesInvalidIdExist = createInterestsDto.InterestsIds.Any(i => Guid.TryParse(i, out Guid result) == false);

            if (doesInvalidIdExist == true)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Invalid interest id"
                });
            }

            if (createInterestsDto.InterestsIds.Count < 2)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "You must submit at least 2 interests"
                });
            }

            try
            {
                await interestService.CreateInterestsByIdsAsync(Guid.Parse(userId!), createInterestsDto.InterestsIds);

                return StatusCode(StatusCodes.Status201Created, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                    Message = "Added interests successfully"
                });
            }
            catch (InvalidOperationException ioe)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = ioe.Message
                });
            }
            catch (NullReferenceException nre)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = nre.Message
                });
            }
        }
    }
}
