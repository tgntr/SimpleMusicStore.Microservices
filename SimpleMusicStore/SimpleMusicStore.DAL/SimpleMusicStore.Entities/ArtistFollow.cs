using SimpleMusicStore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleMusicStore.Entities
{
    public class ArtistFollow : UserActivity
    {
        public ArtistFollow()
			:base()
        {
        }

        public ArtistFollow(int artistId, int userId)
            :base()
        {
            ArtistId = artistId;
            UserId = userId;
        }

        [Required]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        
    }
}
