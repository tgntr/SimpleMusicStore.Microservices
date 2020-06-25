using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        //public ArtistDetails Artist { get; set; }
        //public LabelDetails Label { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
