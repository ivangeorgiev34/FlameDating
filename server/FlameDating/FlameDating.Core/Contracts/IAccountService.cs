using FlameDating.Infrastructure.Dtos.Account;
using FlameDating.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace FlameDating.Core.Contracts
{
    public interface IAccountService
    {
        Task<byte[]?> ConvertProfilePictureIntoByteArray(IFormFile? profilePicture);

        Task EditProfileAsync(User user, EditProfileDto editProfileDto);
    }
}
