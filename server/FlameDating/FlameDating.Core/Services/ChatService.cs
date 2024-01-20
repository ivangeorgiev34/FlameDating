using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Dtos.Account;
using FlameDating.Infrastructure.Dtos.Chat;
using FlameDating.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Core.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository repo;

        public ChatService(IRepository _repo)
        {
            this.repo = _repo;
        }
        public async Task<Guid> CreateChatAsync()
        {
            var chat = new Chat();

            await repo.AddAsync(chat);
            await repo.SaveChangesAsync();

            return chat.Id;
        }

        public async Task<Guid?> GetChatIdBySenderAndRecieverIds(Guid senderId, Guid recieverId)
        {
            var chat = await repo.AllReadonly<Match>()
                .FirstOrDefaultAsync(m => (m.FirstUserId == senderId && m.SecondUserId == recieverId)
                    || (m.FirstUserId == recieverId && m.SecondUserId == senderId));

            return chat?.ChatId;
        }

        public async Task<List<GetUsersChatsDto>> GetUsersChatsAsync(Guid userId)
        {
            var chats = await repo.AllReadonly<Match>()
                .Include(m => m.FirstUser)
                .Include(m => m.SecondUser)
                .Include(m => m.Chat)
                .ThenInclude(c => c.Messages)
                .OrderBy(m => m.Chat.Messages.Select(m => m.Date))
                .Where(m => m.FirstUserId == userId || m.SecondUserId == userId)
                .Select(m => new GetUsersChatsDto()
                {
                    Id = m.Id.ToString(),
                    CurrentUser = m.FirstUserId == userId
                    ? new UserDto()
                    {
                        Id = m.FirstUserId.ToString(),
                        Age = m.FirstUser.Age,
                        Biography = m.FirstUser.Biography,
                        FirstName = m.FirstUser.FirstName,
                        LastName = m.FirstUser.LastName,
                        MiddleName = m.FirstUser.MiddleName,
                        Gender = m.FirstUser.Gender,
                        Job = m.FirstUser.Job,
                        Height = m.FirstUser.Height,
                        LocationLatitude = m.FirstUser.LocationLatitude,
                        LocationLongitude = m.FirstUser.LocationLongitude,
                        School = m.FirstUser.School,
                        FirstProfilePicture = Convert.ToBase64String(m.FirstUser.FirstProfilePicture),
                        SecondProfilePicture = m.FirstUser.SecondProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.SecondProfilePicture)
                        : null,
                        ThirdProfilePicture = m.FirstUser.ThirdProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.ThirdProfilePicture)
                        : null,
                        FourthProfilePicture = m.FirstUser.FourthProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.FourthProfilePicture)
                        : null,
                        FifthProfilePicture = m.FirstUser.FifthProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.FifthProfilePicture)
                        : null
                    }
                    : new UserDto()
                    {
                        Id = m.SecondUserId.ToString(),
                        Age = m.SecondUser.Age,
                        Biography = m.SecondUser.Biography,
                        FirstName = m.SecondUser.FirstName,
                        LastName = m.SecondUser.LastName,
                        MiddleName = m.SecondUser.MiddleName,
                        Gender = m.SecondUser.Gender,
                        Job = m.SecondUser.Job,
                        Height = m.SecondUser.Height,
                        LocationLatitude = m.SecondUser.LocationLatitude,
                        LocationLongitude = m.SecondUser.LocationLongitude,
                        School = m.SecondUser.School,
                        FirstProfilePicture = Convert.ToBase64String(m.SecondUser.FirstProfilePicture),
                        SecondProfilePicture = m.SecondUser.SecondProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.SecondProfilePicture)
                        : null,
                        ThirdProfilePicture = m.SecondUser.ThirdProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.ThirdProfilePicture)
                        : null,
                        FourthProfilePicture = m.SecondUser.FourthProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.FourthProfilePicture)
                        : null,
                        FifthProfilePicture = m.SecondUser.FifthProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.FifthProfilePicture)
                        : null
                    },
                    RecipientUser = m.SecondUserId == userId
                    ? new UserDto()
                    {
                        Id = m.FirstUserId.ToString(),
                        Age = m.FirstUser.Age,
                        Biography = m.FirstUser.Biography,
                        FirstName = m.FirstUser.FirstName,
                        LastName = m.FirstUser.LastName,
                        MiddleName = m.FirstUser.MiddleName,
                        Gender = m.FirstUser.Gender,
                        Job = m.FirstUser.Job,
                        Height = m.FirstUser.Height,
                        LocationLatitude = m.FirstUser.LocationLatitude,
                        LocationLongitude = m.FirstUser.LocationLongitude,
                        School = m.FirstUser.School,
                        FirstProfilePicture = Convert.ToBase64String(m.FirstUser.FirstProfilePicture),
                        SecondProfilePicture = m.FirstUser.SecondProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.SecondProfilePicture)
                        : null,
                        ThirdProfilePicture = m.FirstUser.ThirdProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.ThirdProfilePicture)
                        : null,
                        FourthProfilePicture = m.FirstUser.FourthProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.FourthProfilePicture)
                        : null,
                        FifthProfilePicture = m.FirstUser.FifthProfilePicture != null
                        ? Convert.ToBase64String(m.FirstUser.FifthProfilePicture)
                        : null
                    }
                    : new UserDto()
                    {
                        Id = m.SecondUserId.ToString(),
                        Age = m.SecondUser.Age,
                        Biography = m.SecondUser.Biography,
                        FirstName = m.SecondUser.FirstName,
                        LastName = m.SecondUser.LastName,
                        MiddleName = m.SecondUser.MiddleName,
                        Gender = m.SecondUser.Gender,
                        Job = m.SecondUser.Job,
                        Height = m.SecondUser.Height,
                        LocationLatitude = m.SecondUser.LocationLatitude,
                        LocationLongitude = m.SecondUser.LocationLongitude,
                        School = m.SecondUser.School,
                        FirstProfilePicture = Convert.ToBase64String(m.SecondUser.FirstProfilePicture),
                        SecondProfilePicture = m.SecondUser.SecondProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.SecondProfilePicture)
                        : null,
                        ThirdProfilePicture = m.SecondUser.ThirdProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.ThirdProfilePicture)
                        : null,
                        FourthProfilePicture = m.SecondUser.FourthProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.FourthProfilePicture)
                        : null,
                        FifthProfilePicture = m.SecondUser.FifthProfilePicture != null
                        ? Convert.ToBase64String(m.SecondUser.FifthProfilePicture)
                        : null
                    },
                    UnseenMessagesCount = m.Chat.Messages.Count(m => m.IsSeen == false)
                })
                .ToListAsync();

            return chats;
        }
    }
}
