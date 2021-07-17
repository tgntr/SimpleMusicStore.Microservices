using SimpleMusicStore.Constants;
using SimpleMusicStore.Models.MusicLibraries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleMusicStore.Models.Binding
{
    public class NewRecord
    {
        public NewRecord()
        {
            Images = new List<ImageInfo>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Range(1, 100.00, ErrorMessage = ErrorMessages.PRICE_LIMIT), Required]
        public decimal Price { get; set; }
        [Range(1,int.MaxValue), Required]
        public int Quantity { get; set; }
        [MinLength(1), Required]
        public IEnumerable<RecordLabelInfo> Labels { get; set; }
        [MinLength(1), Required]
        public IEnumerable<RecordArtistInfo> Artists { get; set; }
        public LabelInfo Label { get; set; }
        public ArtistInfo Artist { get; set; }
        public IEnumerable<ImageInfo> Images { get; set; }
        [MinLength(1), Required]
        public IEnumerable<string> Genres { get; set; }
        [MinLength(1), Required]
        public IEnumerable<RecordTrackInfo> Tracklist { get; set; }
        [MinLength(1), Required]
        public IEnumerable<RecordFormatInfo> Formats { get; set; }

        public string Format() => Formats.First().Name;
        public string Image()
        {
            if (Images is null || !Images.Any())
                return DiscogsConstants.DEFAULT_IMAGE;
            else
                return Images.First().Uri;
        }
        public string ArtistId() => Artists.First().Id;
        public string LabelId() => Labels.First().Id;
        public string Genre() => Genres.First();
    }
}
