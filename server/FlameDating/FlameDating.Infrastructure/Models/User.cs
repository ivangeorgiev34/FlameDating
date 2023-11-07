using FlameDating.Infrastructure.Constants;
using FlameDating.Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlameDating.Infrastructure.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.UsersInterests = new List<UserInterest>();
            this.Likes = new List<Like>();
            this.Matches = new List<Match>();
        }

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

        [Required(ErrorMessage = InfrastructureConstants.User.LOCATION_REQUIRED_ERROR_MESSAGE)]
        public decimal LocationLatitude { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.User.LOCATION_REQUIRED_ERROR_MESSAGE)]
        public decimal LocationLongitude { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.User.FIRST_PROFILE_PICTURE_REQUIRED_ERROR_MESSAGE)]
        public byte[] FirstProfilePicture { get; set; } = null!;

        public byte[]? SecondProfilePicture { get; set; }

        public byte[]? ThirdProfilePicture { get; set; }

        public byte[]? FourthProfilePicture { get; set; }

        public byte[]? FifthProfilePicture { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.User.PREFERENCE_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(Preference))]
        public Guid PreferenceId { get; set; }
        public Preference Preference { get; set; } = null!;

        public ICollection<UserInterest> UsersInterests { get; set; } = null!;

        public ICollection<Like> Likes { get; set; } = null!;

        public ICollection<Match> Matches { get; set; } = null!;
    }
}
