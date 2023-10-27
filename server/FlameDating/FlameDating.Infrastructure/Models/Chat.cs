using System.ComponentModel.DataAnnotations;

namespace FlameDating.Infrastructure.Models
{
    public class Chat
    {
        public Chat()
        {
            this.Messages = new List<Message>();
        }

        [Key]
        public Guid Id { get; set; }

        public ICollection<Message> Messages { get; set; } = null!;
    }
}
