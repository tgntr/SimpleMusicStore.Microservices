using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class Item
    {
        public Item()
        {
            Quantity = 1;
        }

        [Required]
        public int RecordId { get; set; }
        public virtual Record Record { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public int Quantity { get; set; }
    }
}