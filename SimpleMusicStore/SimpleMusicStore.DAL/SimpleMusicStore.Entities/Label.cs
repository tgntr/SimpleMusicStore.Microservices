using SimpleMusicStore.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Label : EntityWithCustomId<int>
    {
        public Label()
        {
            Records = new List<Record>();
            Followers = new List<LabelFollow>();
        }

        [Required]
        public string Name { get; set; }

        [Url]
        public string Image { get; set; } 

        public virtual ICollection<Record> Records { get; set; }

        public virtual ICollection<LabelFollow> Followers { get; set; }

    }
}
