using SimpleMusicStore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleMusicStore.Entities
{
    public class Record : EntityWithCustomId<int>
    {
        public Record()
        {
            Tracklist = new List<Track>();
            WishedBy = new List<Wish>();
            Orders = new List<Item>();
            Stocks = new List<Stock>();
            DateAdded = DateTime.UtcNow;
            IsActive = true;
        }

        [Required]
        public string Title { get; set; }
        [Url]
        public string Image { get; set; } 
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        public string Format { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        [Required]
        public int LabelId { get; set; }
        public virtual Label Label { get; set; }
        public virtual ICollection<Wish> WishedBy { get; set; }
        public virtual ICollection<Item> Orders { get; set; }
        public virtual ICollection<Track> Tracklist { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int Popularity() => (Orders.Sum(i => i.Quantity) * 2) + WishedBy.Count;
        public int Availability() => Stocks.Sum(s => s.Quantity) - Orders.Sum(i => i.Quantity);

    }
}
