using Microsoft.Extensions.Options;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.JwtAuthConfiguration;
using SimpleMusicStore.Models;
using System.Threading.Tasks;

namespace SimpleMusicStore.Auth
{
    public class DevAuthenticator : AuthenticationHandler
    {
        private readonly JwtConfiguration _config;
        private readonly IUserRepository _users;

        public DevAuthenticator(IUserRepository users, IOptions<JwtConfiguration> config)
        {
            _users = users;
            _config = config.Value;
        }

        public async Task<string> Google(string token)
        {
            var email = $"{token}@aaa.aa";

            if (await _users.Exists(email))
            {
                return "exists";
            }

            await _users.Add(new UserClaims(email, email));
            await _users.SaveChanges();
            var user = await _users.Find(email);

            return user.Id.ToString();
        }
    }
}
