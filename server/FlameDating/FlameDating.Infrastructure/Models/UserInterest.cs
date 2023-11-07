using System.ComponentModel.DataAnnotations.Schema;

namespace FlameDating.Infrastructure.Models
{
    public class UserInterest
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey(nameof(Interest))]
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; } = null!;
    }
}
