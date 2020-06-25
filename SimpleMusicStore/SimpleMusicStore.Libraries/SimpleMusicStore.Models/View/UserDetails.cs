using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class UserDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<WishDetails> Wishlist { get; set; }
        public IEnumerable<ArtistFollowDetails> FollowedArtists { get; set; }
        public IEnumerable<LabelFollowDetails> FollowedLabels { get; set; }
        public IEnumerable<OrderView> Orders { get; set; }
    }
}
