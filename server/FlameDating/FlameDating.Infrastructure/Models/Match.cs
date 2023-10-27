using FlameDating.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlameDating.Infrastructure.Models
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Match.MATCH_DATE_REQUIRED_ERROR_MESSAGE)]
        public DateTime MatchDate { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Match.FIRST_USER_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(FirstUser))]
        public Guid FirstUserId { get; set; }
        public User FirstUser { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.Match.SECOND_USER_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(SecondUser))]
        public Guid SecondUserId { get; set; }
        public User SecondUser { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.Match.SECOND_USER_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(Chat))]
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } = null!;
    }
}
