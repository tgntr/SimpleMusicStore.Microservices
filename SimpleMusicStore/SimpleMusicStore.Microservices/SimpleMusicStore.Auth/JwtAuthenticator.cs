using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Entities;
using SimpleMusicStore.JwtAuthConfiguration;
using SimpleMusicStore.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace SimpleMusicStore.Auth
{
    public class JwtAuthenticator : AuthenticationHandler
    {
        private readonly JwtConfiguration _config;
        private readonly IUserRepository _users;

        public JwtAuthenticator(IUserRepository users)
        {
            //TODO temp, JwtConfiguration should be injected
            _config = new JwtConfiguration();
            _users = users;
        }

        public async Task<string> Google(string token)
        {
            var tokenDetails = await GetGoogleToken(token);
            await AddNewUser(tokenDetails);

            var user = await _users.Find(tokenDetails.Email);
            var userClaims = GenerateClaims(user);

            return _config.GenerateJwtToken(userClaims);
        }

        private async Task AddNewUser(Payload tokenDetails)
        {
            if (!await _users.Exists(tokenDetails.Email))
            {
                var newUser = new UserClaims(tokenDetails.Name, tokenDetails.Email);
                await _users.Add(newUser);
                await _users.SaveChanges();
            }
        }

        private IEnumerable<Claim> GenerateClaims(UserClaims user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email)
            };
        }

        private async Task<Payload> GetGoogleToken(string token)
        {
            var userInfo = await GoogleJsonWebSignature.ValidateAsync(token);
            if (userInfo == null)
            {
                throw new ArgumentException(ErrorMessages.INVALID_TOKEN);
            }

            return userInfo;
        }
    }
}
