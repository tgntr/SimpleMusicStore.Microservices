using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models
{
    public class UserClaims
    {
        public UserClaims()
        {

        }

        public UserClaims(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
