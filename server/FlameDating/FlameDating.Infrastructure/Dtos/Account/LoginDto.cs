using FlameDating.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace FlameDating.Infrastructure.Dtos.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = InfrastructureConstants.RegisterDto.EMAIL_REQUIRED_ERROR_MESSAGE)]
        [EmailAddress(ErrorMessage = InfrastructureConstants.RegisterDto.EMAIL_INVALID_ERROR_MESSAGE)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.RegisterDto.PASSWORD_REQUIRED_ERROR_MESSAGE)]
        public string Password { get; set; } = null!;
    }
}
