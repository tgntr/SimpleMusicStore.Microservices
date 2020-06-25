using AutoMapper;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using SimpleMusicStore.Contracts;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Models.MessageBus;
using SimpleMusicStore.Models.View;
using SimpleMusicStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Auth
{
    public class MessageListener
    {
        private readonly AuthenticationHandler _authenticator;
        private readonly IBus _messageBus;

        public MessageListener(AuthenticationHandler authenticator, IBus messageBus)
        {
            _messageBus = messageBus;
            _authenticator = authenticator;
        }

        public void ListenForMessages()
        {
            _messageBus.RespondAsync<AuthenticationRequest, string>(request => _authenticator.Google(request.GoogleToken));
        }
    }
}
