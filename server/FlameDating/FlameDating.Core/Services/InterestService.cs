using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Dtos.Interest;
using FlameDating.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Core.Services
{
    public class InterestService : IInterestService
    {
        private readonly IRepository repo;

        public InterestService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task CreateInterestsByIdsAsync(Guid userId, List<string> interestsIds)
        {
            var uniqueInterestsIds = interestsIds.Distinct().ToList();

            var userInterestPairs = new List<UserInterest>();

            foreach (var uniqueInterestId in uniqueInterestsIds)
            {
                var interestIdGuid = Guid.Parse(uniqueInterestId);

                var interestExists = await repo.AllReadonly<Interest>()
                .AnyAsync(i => i.Id == interestIdGuid);

                if (interestExists == false)
                {
                    throw new NullReferenceException("Interest does not exist");
                }

                var userInterest = await repo.AllReadonly<UserInterest>()
                    .Include(ui => ui.Interest)
                    .FirstOrDefaultAsync(ui => ui.InterestId == interestIdGuid && ui.UserId == userId);

                if (userInterest != null)
                {
                    throw new InvalidOperationException($"User already has interest: {userInterest.Interest.Name}");
                }

                var userInterestPair = new UserInterest()
                {
                    InterestId = interestIdGuid,
                    UserId = userId
                };

                userInterestPairs.Add(userInterestPair);
            }

            await repo.AddRangeAsync(userInterestPairs);

            await repo.SaveChangesAsync();
        }

        public async Task EditInterestsByIdsAsync(Guid userId, List<string> interestsIds)
        {
            var currentUserInterestsPairs = await repo.All<UserInterest>()
                .Where(ui => ui.UserId == userId)
                .ToListAsync();

            repo.DeleteRange(currentUserInterestsPairs);

            var newUserInterestsPairs = new List<UserInterest>();

            foreach (var uniqueInterestId in interestsIds)
            {
                var interestId = Guid.Parse(uniqueInterestId);

                var interestExists = await repo.AllReadonly<Interest>()
                .AnyAsync(i => i.Id == interestId);

                if (interestExists == false)
                {
                    throw new NullReferenceException("Interest does not exist");
                }

                var userInterestPair = new UserInterest()
                {
                    UserId = userId,
                    InterestId = interestId
                };

                newUserInterestsPairs.Add(userInterestPair);
            }

            await repo.AddRangeAsync(newUserInterestsPairs);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<InterestDto>> GetAllInterestsAsync()
        {
            var interests = await repo.AllReadonly<Interest>()
                .Select(i => new InterestDto()
                {
                    Id = i.Id.ToString(),
                    Name = i.Name
                })
                .OrderBy(i => i.Name)
                .ToListAsync();

            return interests;
        }

        public async Task<IEnumerable<InterestDto>> GetUsersInterestsByIdAsync(Guid userId)
        {
            var interests = await repo.AllReadonly<UserInterest>()
                .Include(ui => ui.Interest)
                .Where(ui => ui.UserId == userId)
                .Select(i => new InterestDto()
                {
                    Id = i.InterestId.ToString(),
                    Name = i.Interest.Name
                })
                .OrderBy(i => i.Name)
                .ToListAsync();

            return interests;
        }
    }
}
