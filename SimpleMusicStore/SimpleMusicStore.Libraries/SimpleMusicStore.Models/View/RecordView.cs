using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class RecordView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public IEnumerable<VideoDetails> Videos { get; set; }
        public IEnumerable<TrackDetails> Tracklist { get; set; }
        public ArtistDetails Artist { get; set; }
        public LabelDetails Label { get; set; }
        public decimal Price { get; set; }
        public string Format { get; set; }
        public bool IsInWishlist { get; set; }
    }
}
