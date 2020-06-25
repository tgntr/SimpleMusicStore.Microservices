using SimpleMusicStore.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Wish : UserActivity
    {
        public Wish()
			:base()
        {
        }

        public Wish(int recordId, int userId)
            :base()
        {
            RecordId = recordId;
            UserId = userId;
        }

        [Required]
        public int RecordId { get; set; }
        public virtual Record Record { get; set; }

    }
}
