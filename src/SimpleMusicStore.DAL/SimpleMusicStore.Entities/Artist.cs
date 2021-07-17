using SimpleMusicStore.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Artist : EntityWithCustomId<int>
	{
        public Artist()
        {
            Records = new List<Record>();
            Followers = new List<ArtistFollow>();
            Image = @"https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/12in-Vinyl-LP-Record-Angle.jpg/330px-12in-Vinyl-LP-Record-Angle.jpg";
        }

        [Required]
        public string Name { get; set; }

        [Url]
        public string Image { get; set; }

        //TODO should navigation properties be virtual?
        public virtual ICollection<Record> Records { get; set; }

        public virtual ICollection<ArtistFollow> Followers { get; set; }
    }
}
