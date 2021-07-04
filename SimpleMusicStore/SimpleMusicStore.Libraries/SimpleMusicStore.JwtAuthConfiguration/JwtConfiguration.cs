using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
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
		public const string
			SECRET = "Secret",
			ISSUER = "Issuer",
			SUBJECT = "Subject",
			AUDIENCE = "Audience",
			EXPIRATION = "Expiration",
			NOT_BEFORE = "NotBefore",
			ISSUED_AT = "IssuedAt",
			JTI = "Jti";

		private const int DEFAULT_DURATION = 300;
		//TODO proper configuration in appsettings
		//TODO should this class be in Models or Auth project?
        [JsonProperty(SECRET)]
        public string Secret { private get; set; } = "SimpleMusicStoreAuthorizationSecret";

		[JsonProperty(ISSUER)]
		public string Issuer { private get; set; } = "SimpleMusicStore";

		[JsonProperty(SUBJECT)]
		public string Subject { private get; set; }

		[JsonProperty(AUDIENCE)]
        public string Audience { private get; set; } = "SimpleMusicStore";

		[JsonProperty(EXPIRATION)]
		public int Expiration { private get; set; } = DEFAULT_DURATION;

		[JsonProperty(NOT_BEFORE)]
		private DateTime NotBefore => DateTime.UtcNow;

		//TODO maybe DateTime.UtcNow is repeating too much in the whole project
		[JsonProperty(ISSUED_AT)]
		private DateTime IssuedAt => DateTime.UtcNow;

		[JsonProperty(JTI)]
		private string Jti => Guid.NewGuid().ToString();

		private DateTime ExpirationDate => IssuedAt.AddMinutes(Expiration);

		private SymmetricSecurityKey SigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));

		private SigningCredentials SigningCredentials => new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256);

		public string GenerateJwtToken(IEnumerable<Claim> claims)
		{
			var token = SecurityToken(claims);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public TokenValidationParameters ValidationParameters()
		{
			return new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = Issuer,

				ValidateAudience = true,
				ValidAudience = Audience,

				ValidateIssuerSigningKey = true,
				IssuerSigningKey = SigningKey,

				RequireExpirationTime = false,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
		}

		private SecurityToken SecurityToken(IEnumerable<Claim> claims)
		{
			return new JwtSecurityToken(
				issuer: Issuer,
				audience: Audience,
				claims: claims,
				notBefore: NotBefore,
				expires: ExpirationDate,
				signingCredentials: SigningCredentials
			);
		}
	}
}
