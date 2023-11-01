using FlameDating.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlameDating.Infrastructure.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = InfrastructureConstants.Message.TEXT_REQUIRED_ERROR_MESSAGE)]
        public string Text { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.Message.DATE_REQUIRED_ERROR_MESSAGE)]
        public DateTime Date { get; set; }

        public bool IsSeen { get; set; } = false;

        [Required(ErrorMessage = InfrastructureConstants.Message.SENDER_USER_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(Sender))]
        public Guid SenderUserId { get; set; }
        public User Sender { get; set; } = null!;

        [Required(ErrorMessage = InfrastructureConstants.Message.RECIEVER_USER_ID_REQUIRED_ERROR_MESSAGE)]
        [ForeignKey(nameof(Reciever))]
        public Guid RecieverUserId { get; set; }
        public User Reciever { get; set; } = null!;
    }
}
