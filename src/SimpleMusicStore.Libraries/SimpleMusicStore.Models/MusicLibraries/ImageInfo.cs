using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Models.MusicLibraries
{
    public class ImageInfo
    {
        [Required]
        public string Uri { get; set; }
    }
}