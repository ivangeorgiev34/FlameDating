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

        public async Task DislikeUserAsync(Guid dislikerUserId, Guid dislikedUserId)
        {
            var dislikedUserAlreadyDisliked = await repo.AllReadonly<Like>()
                 .AnyAsync(l => l.LikedUserId == dislikedUserId
                     && l.LikerUserId == dislikerUserId
                    && l.LikeStatus == LikeStatus.Dislike);

            if (dislikedUserAlreadyDisliked == true)
            {
                throw new InvalidOperationException("You have already disliked this user");
            }

            var dislikedUserAlreadyLiked = await repo.AllReadonly<Like>()
                .AnyAsync(l => l.LikedUserId == dislikedUserId
                    && l.LikerUserId == dislikerUserId
                    && l.LikeStatus == LikeStatus.Like);

            if (dislikedUserAlreadyLiked == true)
            {
                throw new InvalidOperationException("You have already liked this user");
            }

            var isDislikerUserDisliked = await repo.AllReadonly<Like>()
                 .AnyAsync(l => l.LikedUserId == dislikerUserId
                     && l.LikerUserId == dislikedUserId
                     && l.LikeStatus == LikeStatus.Dislike);

            if (isDislikerUserDisliked == false)
            {
                var like = new Like()
                {
                    LikerUserId = dislikerUserId,
                    LikedUserId = dislikedUserId,
                    LikeStatus = LikeStatus.Dislike,
                    LikeDate = DateTime.Now
                };

                await repo.AddAsync(like);
                await repo.SaveChangesAsync();
            }
        }

        public async Task<bool> LikeUserAsync(Guid likerUserId, Guid likedUserId)
        {
            var dislikedUserAlreadyDisliked = await repo.AllReadonly<Like>()
                .AnyAsync(l => l.LikedUserId == likedUserId
                    && l.LikerUserId == likerUserId
                    && l.LikeStatus == LikeStatus.Dislike);

            if (dislikedUserAlreadyDisliked == true)
            {
                throw new InvalidOperationException("You have already disliked this user");
            }

            var likedUserAlreadyLiked = await repo.AllReadonly<Like>()
                .AnyAsync(l => l.LikedUserId == likedUserId
                    && l.LikerUserId == likerUserId
                    && l.LikeStatus == LikeStatus.Like);

            if (likedUserAlreadyLiked == true)
            {
                throw new InvalidOperationException("You have already liked this user");
            }

            var isLikerUserLiked = await repo.AllReadonly<Like>()
                .AnyAsync(l => l.LikedUserId == likerUserId
                    && l.LikerUserId == likedUserId
                    && l.LikeStatus == LikeStatus.Like);

            if (isLikerUserLiked == true)
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
