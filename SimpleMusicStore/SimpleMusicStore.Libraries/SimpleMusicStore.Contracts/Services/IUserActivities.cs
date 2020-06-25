using SimpleMusicStore.Models.View;
using System.Collections.Generic;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IUserActivities
    {
        IEnumerable<WishDetails> Wishlist { get; }
        IEnumerable<ArtistFollowDetails> FollowedArtists { get; }
        IEnumerable<LabelFollowDetails> FollowedLabels { get; }
        IEnumerable<OrderView> Orders { get; }
        IEnumerable<OrderDetails> OrdersOrdered(int page);
        IEnumerable<WishDetails> WishlistOrdered(int page);
        IEnumerable<ArtistFollowDetails> FollowedArtistsOrdered(int page);
        IEnumerable<LabelFollowDetails> FollowedLabelsOrdered(int page);
        bool IsRecordInWishlist(int recordId);
        bool IsArtistFollowed(int artistId);
        bool IsLabelFollowed(int labelId);
        bool IsAuthenticated { get; }
    }
}
