using FlameDating.Infrastructure.Constants;
using FlameDating.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlameDating.Infrastructure.Models
{
    public class Like
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Like.LIKE_STATUS_REQUIRED_ERROR_MESSAGE)]
        [EnumDataType(typeof(Gender),
            ErrorMessage = InfrastructureConstants.Like.LIKE_STATUS_DATA_TYPE_ERROR_MESSAGE)]
        public LikeStatus LikeStatus { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Like.LIKE_DATE_REQUIRED_ERROR_MESSAGE)]
        public DateTime LikeDate { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Like.LIKER_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(Liker))]
        public Guid LikerUserId { get; set; }
        public User Liker { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.Like.LIKED_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(Liked))]
        public Guid LikedUserId { get; set; }
        public User Liked { get; set; } = null!;
    }
}
