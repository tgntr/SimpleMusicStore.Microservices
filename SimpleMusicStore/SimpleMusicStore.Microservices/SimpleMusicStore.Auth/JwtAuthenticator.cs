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
    public class JwtAuthenticator : AuthenticationHandler
    {
        private readonly JwtConfiguration _config;
        private readonly IUserRepository _users;

        public JwtAuthenticator(IUserRepository users, JwtConfiguration config)
        {
            _users = users;
            _config = config;
        }

        public async Task<string> Google(string token)
        {
            var userInfo = await GoogleJsonWebSignature.ValidateAsync(token);
            ValidateToken(userInfo);

            if (!await _users.Exists(userInfo.Email))
            {
                await _users.Add(new UserClaims(userInfo.Name, userInfo.Email));
                await _users.SaveChanges();
            }

            var user = await _users.Find(userInfo.Email);

            return GenerateJwtToken(GenerateClaims(user));
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

        private static void ValidateToken(GoogleJsonWebSignature.Payload userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentException(ErrorMessages.INVALID_TOKEN);
            }
        }

        private string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var token = _config.SecurityToken(claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
