using SimpleMusicStore.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMusicStore.Entities
{
    public class SimpleUser : Entity<int>
    {
        public SimpleUser()
        {
            IsSubscribed = true;
        }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool IsSubscribed { get; set; }
        
    }
}
