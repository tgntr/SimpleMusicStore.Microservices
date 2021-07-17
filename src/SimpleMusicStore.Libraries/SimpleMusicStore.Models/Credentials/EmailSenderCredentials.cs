using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.Credentials
{
    public class EmailSenderCredentials
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
