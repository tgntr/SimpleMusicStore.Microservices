using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IFollowService
    {
        Task AddToWishlist(int recordId);
        Task RemoveFromWishlist(int recordId);
        Task FollowArtist(int artistId);
        Task UnfollowArtist(int artistId);
        Task FollowLabel(int labelId);
        Task UnfollowLabel(int labelId);
        
    }
}
