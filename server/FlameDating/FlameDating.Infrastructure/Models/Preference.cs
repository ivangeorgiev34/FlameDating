using FlameDating.Infrastructure.Constants;
using FlameDating.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlameDating.Infrastructure.Models
{
    public class Preference
    {
        [Key]
        public Guid Id { get; set; }

        [Range(InfrastructureConstants.Preference.MAXIMUM_DISTANCE_MIN_VALUE,
            InfrastructureConstants.Preference.MAXIMUM_DISTANCE_MAX_VALUE,
            ErrorMessage = InfrastructureConstants.Preference.MAXIMUM_DISTANCE_VALUE_ERROR_MESSAGE)]
        public int MaximumDistance { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Preference.GENDER_REQUIRED_ERROR_MESSAGE)]
        [EnumDataType(typeof(Gender),
            ErrorMessage = InfrastructureConstants.Preference.GENDER_DATA_TYPE_ERROR_MESSAGE)]
        public Gender Gender { get; set; }
    }
}
