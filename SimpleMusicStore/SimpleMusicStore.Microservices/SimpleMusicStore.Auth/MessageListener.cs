using EasyNetQ;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Models.MessageBus;

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
