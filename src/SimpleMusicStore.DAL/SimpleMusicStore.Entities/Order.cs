using SimpleMusicStore.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleMusicStore.Entities
{
    public class Order : UserActivity
    {
        public Order()
			:base()
        {
        }

        public int Id { get; set; }

		//TODO check if works
		public decimal TotalPrice => Items.Sum(i => i.Record.Price * i.Quantity);

        [Required]
        public int DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
