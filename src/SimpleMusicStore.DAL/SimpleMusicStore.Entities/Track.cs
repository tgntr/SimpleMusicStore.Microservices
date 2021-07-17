using SimpleMusicStore.Constants;
using SimpleMusicStore.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Track : Entity<int>
    {
        [Required]
        public string Title { get; set; }
        public string Duration { get; set; }
        [Required]
        public int RecordId { get; set; }
        public virtual Record Record { get; set; }
        public string Preview() => CommonConstants.STORAGE_URL + RecordId + Title;
       
    }
}
