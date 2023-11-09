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
        private readonly IAccountService accountService;

        public InterestController(IInterestService _interestService,
            IAccountService _accountService)
        {
            this.interestService = _interestService;
            this.accountService = _accountService;
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

        [HttpGet]
        [Route("interests")]
        public async Task<IActionResult> GetInterests()
        {
            var interests = await interestService.GetAllInterestsAsync();

            return StatusCode(StatusCodes.Status200OK, new Response()
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                Message = "Interests retrieved successfully",
                Content = new
                {
                    Interests = interests
                }
            });
        }

        [HttpGet]
        [Route("interests/{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUsersInterests(string userId)
        {
            if (IsIdValidGuidAndNotNull(userId) == false
                || await accountService.UserExistsByIdAsync(Guid.Parse(userId)) == false)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User does not exist"
                });
            }

            var interests = await interestService.GetUsersInterestsByIdAsync(Guid.Parse(userId));

            return StatusCode(StatusCodes.Status200OK, new Response()
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                Message = "Users interests retrieved successfully",
                Content = new
                {
                    Interests = interests
                }
            });
        }

        [HttpPut]
        [Route("edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditUsersInterests(EditInterestsDto editInterestsDto)
        {
            var userId = Guid.Parse(GetUserId(this.HttpContext)!);

            var doesInvalidIdExist = editInterestsDto.InterestsIds.Any(i => Guid.TryParse(i, out Guid result) == false);

            if (doesInvalidIdExist == true)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "Invalid interest id"
                });
            }

            var uniqueInterestsIds = editInterestsDto.InterestsIds.Distinct().ToList();

            if (uniqueInterestsIds.Count < 2)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "You must submit at least 2 interests"
                });
            }

            try
            {
                await interestService.EditInterestsByIdsAsync(userId, uniqueInterestsIds);

                return StatusCode(StatusCodes.Status201Created, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                    Message = "Edited interests successfully"
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
