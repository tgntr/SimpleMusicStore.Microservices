using SimpleMusicStore.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Stock : Entity<int>
    {
        public Stock()
        {
            DateAdded = DateTime.UtcNow;
        }

        public Stock(int recordId, int quantity)
        {
            RecordId = recordId;
            Quantity = quantity;
        }

        [Required]
        public int RecordId { get; set; }
        public virtual Record Record { get; set; }
        public DateTime DateAdded { get; set; }
        public int Quantity { get; set; }
    }
}
