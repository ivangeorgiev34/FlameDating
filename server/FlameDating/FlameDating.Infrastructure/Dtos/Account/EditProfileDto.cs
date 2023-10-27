using FlameDating.Infrastructure.Constants;
using FlameDating.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlameDating.Infrastructure.Dtos.Account
{
    public class EditProfileDto
    {
        [Required(ErrorMessage = InfrastructureConstants.User.FIRST_NAME_REQUIRED_ERROR_MESSAGE)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.User.MIDDLE_NAME_REQUIRED_ERROR_MESSAGE)]
        public string MiddleName { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.User.LAST_NAME_REQUIRED_ERROR_MESSAGE)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.User.AGE_REQUIRED_ERROR_MESSAGE)]
        [Range(InfrastructureConstants.User.AGE_MIN_VALUE,
          InfrastructureConstants.User.AGE_MAX_VALUE,
          ErrorMessage = InfrastructureConstants.User.AGE_VALUE_ERROR_MESSAGE)]
        public int Age { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.User.GENDER_REQUIRED_ERROR_MESSAGE)]
        [EnumDataType(typeof(Gender),
            ErrorMessage = InfrastructureConstants.User.GENDER_DATA_TYPE_ERROR_MESSAGE)]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.User.HEIGHT_REQUIRED_ERROR_MESSAGE)]
        [Range(InfrastructureConstants.User.HEIGHT_MIN_VALUE,
            InfrastructureConstants.User.HEIGHT_MAX_VALUE,
            ErrorMessage = InfrastructureConstants.User.HEIGHT_VALUE_ERROR_MESSAGE)]
        public double Height { get; set; }

        public string? School { get; set; }

        public string? Job { get; set; }

        public string? Biography { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.User.FIRST_PROFILE_PICTURE_REQUIRED_ERROR_MESSAGE)]
        public IFormFile FirstProfilePicture { get; set; } = null!;

        public IFormFile? SecondProfilePicture { get; set; }

        public IFormFile? ThirdProfilePicture { get; set; }

        public IFormFile? FourthProfilePicture { get; set; }

        public IFormFile? FifthProfilePicture { get; set; }

        [Range(InfrastructureConstants.Preference.MAXIMUM_DISTANCE_MIN_VALUE,
            InfrastructureConstants.Preference.MAXIMUM_DISTANCE_MAX_VALUE,
            ErrorMessage = InfrastructureConstants.Preference.MAXIMUM_DISTANCE_VALUE_ERROR_MESSAGE)]
        public int MaximumDistance { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Preference.GENDER_REQUIRED_ERROR_MESSAGE)]
        [EnumDataType(typeof(Gender),
            ErrorMessage = InfrastructureConstants.Preference.GENDER_DATA_TYPE_ERROR_MESSAGE)]
        public Gender PreferedGender { get; set; }
    }
}
