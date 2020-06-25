using SimpleMusicStore.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Address : Entity<int>
    {
        public Address()
        {
            Orders = new List<Order>();
            IsActive = true;
        }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Country { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string City { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Street { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
