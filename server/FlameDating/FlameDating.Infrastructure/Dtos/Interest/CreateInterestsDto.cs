namespace FlameDating.Infrastructure.Dtos.Interest
{
    public class CreateInterestsDto
    {
        public CreateInterestsDto()
        {
            this.InterestsIds = new List<string>();
        }
        public List<string> InterestsIds { get; set; } = null!;
    }
}
