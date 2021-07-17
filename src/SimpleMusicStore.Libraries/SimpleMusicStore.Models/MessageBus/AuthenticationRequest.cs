using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.MessageBus
{
    public class AuthenticationRequest
    {
        public AuthenticationRequest(string googleToken)
        {
            GoogleToken = googleToken;
        }

        public string GoogleToken { get; set; }
    }
}
