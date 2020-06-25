using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class OrderView
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public AddressDetails DeliveryAddress { get; set; }
        public IEnumerable<ItemDetails> Items { get; set; }
    }
}
