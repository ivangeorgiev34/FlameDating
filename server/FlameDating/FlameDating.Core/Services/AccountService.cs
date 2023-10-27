using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Dtos.Account;
using FlameDating.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace FlameDating.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repo;
        private readonly IPreferenceService preferenceService;

        public AccountService(IRepository _repo,
            IPreferenceService _preferenceService)
        {
            this.repo = _repo;
            this.preferenceService = _preferenceService;
        }

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

        public async Task EditProfileAsync(User user, EditProfileDto editProfileDto)
        {
            var userPreference = await preferenceService.GetPreferenceByIdAsync(user.PreferenceId);

            if (userPreference == null)
            {
                throw new NullReferenceException("User doesn't have preference");
            }

            userPreference.Gender = editProfileDto.Gender;
            userPreference.MaximumDistance = editProfileDto.MaximumDistance;

            user.FirstName = editProfileDto.FirstName;
            user.MiddleName = editProfileDto.MiddleName;
            user.LastName = editProfileDto.LastName;
            user.Age = editProfileDto.Age;
            user.Gender = editProfileDto.Gender;
            user.Height = editProfileDto.Height;
            user.School = editProfileDto.School;
            user.Job = editProfileDto.Job;
            user.Biography = editProfileDto.Biography;
            user.FirstProfilePicture = (await ConvertProfilePictureIntoByteArray(editProfileDto.FirstProfilePicture))!;
            user.SecondProfilePicture = await ConvertProfilePictureIntoByteArray(editProfileDto?.SecondProfilePicture);
            user.ThirdProfilePicture = await ConvertProfilePictureIntoByteArray(editProfileDto?.ThirdProfilePicture);
            user.FourthProfilePicture = await ConvertProfilePictureIntoByteArray(editProfileDto?.FourthProfilePicture);
            user.FifthProfilePicture = await ConvertProfilePictureIntoByteArray(editProfileDto?.FifthProfilePicture);

            await repo.SaveChangesAsync();
        }
    }
}
