using Microsoft.AspNetCore.Http;

namespace FlameDating.Core.Contracts
{
    public interface IAccountService
    {
        Task<byte[]?> ConvertProfilePictureIntoByteArray(IFormFile? profilePicture);
    }
}
