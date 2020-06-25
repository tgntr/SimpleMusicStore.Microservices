using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.Binding
{
    public class NewOrder
    {
        public int UserId { get; set; }
        public int DeliveryAddressId { get; set; }
        public IDictionary<int, int> Items { get; set; }
    }
}
