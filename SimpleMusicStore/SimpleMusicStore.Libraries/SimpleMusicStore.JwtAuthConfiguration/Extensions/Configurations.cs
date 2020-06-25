using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleMusicStore.JwtAuthConfiguration.Extensions
{
	public static class Configurations
	{
		public static SecurityToken SecurityToken(this JwtConfiguration config, IEnumerable<Claim> claims)
		{
            return new JwtSecurityToken(
            	issuer: config.Issuer,
            	audience: config.Audience,
            	claims: claims,
            	notBefore: config.NotBefore,
            	expires: config.ExpirationDate(),
            	signingCredentials: config.SigningCredentials()
            );
        }

		public static TokenValidationParameters ValidationParameters(this JwtConfiguration config)
		{
			return new TokenValidationParameters
			{	
				ValidateIssuer = true,
				ValidIssuer = config.Issuer,
				
				ValidateAudience = true,
				ValidAudience = config.Audience,
				
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = config.SigningKey(),
				
				RequireExpirationTime = false,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
		}
		
		private static SigningCredentials SigningCredentials(this JwtConfiguration config)
		{
			return new SigningCredentials(config.SigningKey(), SecurityAlgorithms.HmacSha256);
		}
		
		private static SymmetricSecurityKey SigningKey(this JwtConfiguration config)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Secret));
		}

		private static DateTime ExpirationDate(this JwtConfiguration config)
		{
			return config.IssuedAt.AddMinutes(config.Expiration);
		}
	}
}
