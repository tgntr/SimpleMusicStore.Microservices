using AutoMapper;
using EasyNetQ;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Models.MessageBus;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.UserActivities
{
    public class MessageListener
    {
        private readonly IUserRepository _users;
        private readonly IMapper _mapper;
        private readonly IBus _messageBus;

        public MessageListener(IUserRepository users, IMapper mapper, IBus messageBus)
        {
            _users = users;
            _mapper = mapper;
            _messageBus = messageBus;
        }

        public void ListenForMessages()
        {
            _messageBus.Respond<UserActivityRequest, IEnumerable<WishDetails>>(request =>
            {
                var userActivities = new UserActivities(request.UserId, _users, _mapper);
                return userActivities.WishlistOrdered(request.Page);
            });
        }
    }
}
