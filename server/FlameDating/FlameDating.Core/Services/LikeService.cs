using FlameDating.Core.Contracts;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Enums;
using FlameDating.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlameDating.Core.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository repo;
        private readonly IMatchService matchService;

        public LikeService(IRepository _repo,
            IMatchService _matchService)
        {
            this.repo = _repo;
            this.matchService = _matchService;
        }

        public async Task<bool> LikeUserAsync(Guid likerUserId, Guid likedUserId)
        {
            var likedAlreadyLiked = await repo.AllReadonly<Like>()
                .AnyAsync(l => l.LikedUserId == likedUserId
                    && l.LikerUserId == likerUserId);

            if (likedAlreadyLiked == true)
            {
                throw new InvalidOperationException("You have already liked this user");
            }

            var isLikerLiked = await repo.AllReadonly<Like>()
                .AnyAsync(l => l.LikedUserId == likerUserId
                    && l.LikerUserId == likedUserId);

            if (isLikerLiked == true)
            {
                var matchExists = await matchService.MatchExistsAsync(likerUserId, likedUserId);

                if (matchExists == true)
                {
                    throw new InvalidOperationException("You have already been liked by this user");
                }

                await matchService.CreateMatchAsync(likerUserId, likedUserId);

                return true;
            }

            var like = new Like()
            {
                LikerUserId = likerUserId,
                LikedUserId = likedUserId,
                LikeStatus = LikeStatus.Like,
                LikeDate = DateTime.Now
            };

            await repo.AddAsync(like);
            await repo.SaveChangesAsync();

            return false;
        }
    }
}
