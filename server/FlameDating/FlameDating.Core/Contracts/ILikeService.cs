﻿namespace FlameDating.Core.Contracts
{
    public interface ILikeService
    {
        Task<bool> LikeUserAsync(Guid likerUserId, Guid likedUserId);
    }
}
