using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Models.MessageBus;
using System.Threading.Tasks;

namespace SimpleMusicStore.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly IBus _messageBus;

        public AuthController(IBus messageBus)
			: base()
		{
            _messageBus = messageBus;
        }

		public Task<string> Google(string token)
		{
            var request = new AuthenticationRequest(token);
            return _messageBus.RequestAsync<AuthenticationRequest, string>(request);
        }
    }
}