using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SimpleMusicStore.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleMusicStore.JwtAuthConfiguration
{
    [JsonObject("JwtPayload")]
    public class JwtConfiguration
    {
        private const int DEFAULT_DURATION = 300;
        private const string
            SECRET = "Secret",
            ISSUER = "Issuer",
            SUBJECT = "Subject",
            AUDIENCE = "Audience",
            EXPIRATION = "Expiration",
            NOT_BEFORE = "NotBefore",
            ISSUED_AT = "IssuedAt",
            JTI = "Jti";
        
        public JwtConfiguration()
        {
            Expiration = DEFAULT_DURATION;
            NotBefore = DateTime.UtcNow;
            IssuedAt = DateTime.UtcNow;
            Jti = Guid.NewGuid().ToString();
        }

        [JsonProperty(SECRET)]
        public string Secret { internal get; set; }

        [JsonProperty(ISSUER)]
        public string Issuer { internal get; set; }

        [JsonProperty(SUBJECT)]
        public string Subject { internal get; set; }

        [JsonProperty(AUDIENCE)]
        public string Audience { internal get; set; }

        [JsonProperty(EXPIRATION)]
        public int Expiration { internal get; set; }

        [JsonProperty(NOT_BEFORE)]
        public DateTime NotBefore { internal get; set; }

		//TODO maybe DateTime.UtcNow is repeating too much in the whole project
        [JsonProperty(ISSUED_AT)]
        public DateTime IssuedAt { internal get; set; }

        [JsonProperty(JTI)]
        public string Jti { internal get; set; }

        public string GenerateJwtToken(UserClaims user)
        {
            var token = GetSecurityToken(user);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Issuer,

                ValidateAudience = true,
                ValidAudience = Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSigningKey(),

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        private SecurityToken GetSecurityToken(UserClaims user)
        {
            return new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: GenerateClaims(user),
                notBefore: NotBefore,
                expires: CalculateExpirationDate(),
                signingCredentials: EncriptSigningKey()
            );
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

        private DateTime CalculateExpirationDate() => 
            IssuedAt.AddMinutes(Expiration);

        private SymmetricSecurityKey GetSigningKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));

        private SigningCredentials EncriptSigningKey() =>
            new SigningCredentials(GetSigningKey(), SecurityAlgorithms.HmacSha256);
    }
}
