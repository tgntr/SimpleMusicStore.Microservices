using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.MessageBus
{
    public class UserActivityRequest
    {
        public UserActivityRequest(int userId, int page)
        {
            Page = page;
            UserId = userId;
        }
        public int Page { get; set; }

        public int UserId { get; set; }
    }
}
