using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.JwtAuthConfiguration;
using SimpleMusicStore.JwtAuthConfiguration.Extensions;
using SimpleMusicStore.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleMusicStore.Auth
{
    public class DevAuthenticator : AuthenticationHandler
    {
        private readonly JwtConfiguration _config;
        private readonly IUserRepository _users;

        public DevAuthenticator(IUserRepository users)
        {
            _users = users;
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
