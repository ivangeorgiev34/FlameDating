using FlameDating.Core.Contracts;
using Microsoft.AspNetCore.Http;

namespace FlameDating.Core.Services
{
    public class AccountService : IAccountService
    {
        public async Task<byte[]?> ConvertProfilePictureIntoByteArray(IFormFile? profilePicture)
        {
            byte[]? imageBytes = null;

            if (profilePicture != null)
            {
                using (var ms = new MemoryStream())
                {
                    await profilePicture.CopyToAsync(ms);
                    imageBytes = ms.ToArray();
                }
            }

            return imageBytes;
        }
    }
}
