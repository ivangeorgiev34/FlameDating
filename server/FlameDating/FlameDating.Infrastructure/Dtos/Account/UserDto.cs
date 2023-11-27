using FlameDating.Infrastructure.Enums;

namespace FlameDating.Infrastructure.Dtos.Account
{
    public class UserDto
    {
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public double Height { get; set; }

        public string? School { get; set; }

        public string? Job { get; set; }

        public string? Biography { get; set; }

        public decimal LocationLatitude { get; set; }

        public decimal LocationLongitude { get; set; }

        public double DistanceFromUser { get; set; }

        public string FirstProfilePicture { get; set; } = null!;

        public string? SecondProfilePicture { get; set; }

        public string? ThirdProfilePicture { get; set; }

        public string? FourthProfilePicture { get; set; }

        public string? FifthProfilePicture { get; set; }
    }
}
