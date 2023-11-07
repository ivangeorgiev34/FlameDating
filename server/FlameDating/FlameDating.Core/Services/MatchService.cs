using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Dtos.Account;
using FlameDating.Infrastructure.Models;
using Geolocation;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepository repo;
        private readonly IChatService chatService;

        public MatchService(IRepository _repo,
            IChatService _chatService)
        {
            this.repo = _repo;
            this.chatService = _chatService;
        }

        public async Task CreateMatchAsync(Guid firstUserId, Guid secondUserId)
        {
            var chatId = await chatService.CreateChatAsync();

            var match = new Match()
            {
                FirstUserId = firstUserId,
                SecondUserId = secondUserId,
                ChatId = chatId,
                MatchDate = DateTime.Now
            };

            await repo.AddAsync(match);
            await repo.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetUserSuggestedMatchesByIdAsync(Guid userId)
        {
            var user = await repo.AllReadonly<User>()
                .Include(u => u.UsersInterests)
                .ThenInclude(ui => ui.Interest)
                .Include(u => u.Preference)
                .Include(u => u.Likes)
                .Include(u => u.Matches)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new NullReferenceException("User does not exist");
            }

            var suggestedMatches = repo.AllReadonly<User>()
                .Include(u => u.UsersInterests)
                .ThenInclude(ui => ui.Interest)
                .Include(u => u.Preference)
                .Include(u => u.Likes)
                .Where(u => u.Gender == user.Preference.Gender
                        && u.Id != user.Id)
                .AsEnumerable()
                .Where(u => Math.Floor(GeoCalculator.GetDistance(decimal.ToDouble(user.LocationLatitude),
                decimal.ToDouble(user.LocationLongitude), decimal.ToDouble(u.LocationLatitude),
                decimal.ToDouble(u.LocationLongitude), 1, DistanceUnit.Kilometers))
                <= user.Preference.MaximumDistance
                        && user.Likes.Any(l => DateTime.Now.DayOfYear - l.LikeDate.DayOfYear >= 30
                            && (l.LikerUserId == u.Id || l.LikedUserId == u.Id)) == false
                        && user.UsersInterests.Count(ui => u.UsersInterests.Any(i => i.Interest.Name == ui.Interest.Name)) >= 2)
                .Select(u => new UserDto()
                {
                    Id = u.Id.ToString(),
                    Age = u.Age,
                    Biography = u.Biography,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    MiddleName = u.MiddleName,
                    Gender = u.Gender,
                    Job = u.Job,
                    Height = u.Height,
                    LocationLatitude = u.LocationLatitude,
                    LocationLongitude = u.LocationLongitude,
                    School = u.School,
                    FirstProfilePicture = Convert.ToBase64String(u.FirstProfilePicture),
                    SecondProfilePicture = u.SecondProfilePicture != null
                        ? Convert.ToBase64String(u.SecondProfilePicture)
                        : null,
                    ThirdProfilePicture = u.ThirdProfilePicture != null
                        ? Convert.ToBase64String(u.ThirdProfilePicture)
                        : null,
                    FourthProfilePicture = u.FourthProfilePicture != null
                        ? Convert.ToBase64String(u.FourthProfilePicture)
                        : null,
                    FifthProfilePicture = u.FifthProfilePicture != null
                        ? Convert.ToBase64String(u.FifthProfilePicture)
                        : null
                })
                .ToList();

            return suggestedMatches;
        }

        public async Task<bool> MatchExistsAsync(Guid firstUserId, Guid secondUserId)
        {
            var matchExists = await repo.AllReadonly<Match>()
                .AnyAsync(u => (u.Id == firstUserId && u.SecondUserId == secondUserId)
                || (u.Id == secondUserId && u.SecondUserId == firstUserId));

            return matchExists;
        }
    }
}
