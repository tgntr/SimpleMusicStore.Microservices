using SimpleMusicStore.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class User : Entity<int>
    {
        public User()
        {
            Addresses = new List<Address>();
            FollowedArtists = new List<ArtistFollow>();
            FollowedLabels = new List<LabelFollow>();
            Wishlist = new List<Wish>();
            Orders = new List<Order>();
            IsSubscribed = true;
        }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsSubscribed { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ArtistFollow> FollowedArtists { get; set; }
        public virtual ICollection<LabelFollow> FollowedLabels { get; set; }
        public virtual ICollection<Wish> Wishlist { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
    }
}
