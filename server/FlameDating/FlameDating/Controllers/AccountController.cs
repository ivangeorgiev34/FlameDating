using FlameDating.Constants;
using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Dtos.Account;
using FlameDating.Infrastructure.Models;
using FlameDating.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlameDating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly IPreferenceService preferenceService;
        private readonly IAccountService accountService;

        public AccountController(UserManager<User> _userManager,
            IConfiguration _configuration,
            IPreferenceService _preferenceService,
            IAccountService _accountService)
        {
            this.userManager = _userManager;
            this.configuration = _configuration;
            this.preferenceService = _preferenceService;
            this.accountService = _accountService;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            var userExists = await userManager.FindByEmailAsync(registerDto.Email);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User already exists"
                });
            }

            var preferenceId = await preferenceService.CreatePreferenceAsync(registerDto.MaximumDistance, registerDto.PreferedGender);

            var firstProfilePictureBytes = await accountService.ConvertProfilePictureIntoByteArray(registerDto.FirstProfilePicture);
            var secondProfilePictureBytes = await accountService.ConvertProfilePictureIntoByteArray(registerDto.SecondProfilePicture);
            var thirdProfilePictureBytes = await accountService.ConvertProfilePictureIntoByteArray(registerDto.ThirdProfilePicture);
            var fourthProfilePictureBytes = await accountService.ConvertProfilePictureIntoByteArray(registerDto.FourthProfilePicture);
            var fifthProfilePictureBytes = await accountService.ConvertProfilePictureIntoByteArray(registerDto.FifthProfilePicture);

            var user = new User()
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                FirstName = registerDto.FirstName,
                MiddleName = registerDto.MiddleName,
                LastName = registerDto.LastName,
                Age = registerDto.Age,
                Biography = registerDto.Biography,
                Gender = registerDto.Gender,
                Height = registerDto.Height,
                Job = registerDto.Job,
                School = registerDto.School,
                LocationLatitude = registerDto.LocationLatitude,
                LocationLongitude = registerDto.LocationLongitude,
                PreferenceId = preferenceId,
                FirstProfilePicture = firstProfilePictureBytes!,
                SecondProfilePicture = secondProfilePictureBytes,
                ThirdProfilePicture = thirdProfilePictureBytes,
                FourthProfilePicture = fourthProfilePictureBytes,
                FifthProfilePicture = fifthProfilePictureBytes,
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User creation failed"
                });
            }

            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                Message = "User created"
            });
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Response()
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User doesn't exist"
                });
            }

            if (await userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var token = await CreateTokenAsync(user);

                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                    Message = "Login successful",
                    Content = new
                    {
                        user = new
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            MiddleName = user.MiddleName,
                            LastName = user.LastName,
                            Age = user.Age,
                            Email = user.Email,
                            Username = user.UserName,
                            Gender = user.Gender,
                            Biography = user.Biography,
                            School = user.School,
                            Job = user.Job,
                            Height = user.Height,
                            FirstProfilePicture = Convert.ToBase64String(user.FirstProfilePicture)

                        },
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expires = token.ValidTo
                    }
                });
            }

            return StatusCode(StatusCodes.Status404NotFound, new Response
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                Message = "Wrong credentials"
            });
        }

        [HttpPut]
        [Route("/edit/{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditProfile([FromForm] EditProfileDto editProfileDto, string userId)
        {
            if (userId == null || Guid.TryParse(userId, out Guid userIdResult) == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User doesn't exist"
                });
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = "User doesn't exist"
                });
            }

            try
            {
                await accountService.EditProfileAsync(user, editProfileDto);
            }
            catch (NullReferenceException nre)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = ApplicationConstants.Response.RESPONSE_STATUS_ERROR,
                    Message = nre.Message
                });
            }

            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Status = ApplicationConstants.Response.RESPONSE_STATUS_SUCCESS,
                Message = "User edited successfully",
                Content = new
                {
                    user = new
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Age = user.Age,
                        Email = user.Email,
                        Username = user.UserName,
                        Gender = user.Gender,
                        Biography = user.Biography,
                        School = user.School,
                        Job = user.Job,
                        Height = user.Height,
                        FirstProfilePicture = Convert.ToBase64String(user.FirstProfilePicture)
                    }
                }
            });
        }

        private async Task<JwtSecurityToken> CreateTokenAsync(User user)
        {
            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(6),
                claims: authClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
