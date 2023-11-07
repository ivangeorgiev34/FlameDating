using FlameDating.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace FlameDating.Infrastructure.Models
{
    public class Interest
    {
        public Interest()
        {
            this.UsersInterests = new List<UserInterest>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Interest.NAME_REQUIRED_ERROR_MESSAGE)]
        public string Name { get; set; } = null!;

        public ICollection<UserInterest> UsersInterests { get; set; } = null!;
    }
}
