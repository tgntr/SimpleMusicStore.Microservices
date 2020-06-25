using Newtonsoft.Json;
using System;

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
        public string Secret { get; set; }

		[JsonProperty(ISSUER)]
		public string Issuer { get; set; }

		[JsonProperty(SUBJECT)]
		public string Subject { get; set; }

		[JsonProperty(AUDIENCE)]
        public string Audience { get; set; }

		[JsonProperty(EXPIRATION)]
		public int Expiration { get; set; } = DEFAULT_DURATION;

		[JsonProperty(NOT_BEFORE)]
		public DateTime NotBefore => DateTime.UtcNow;

		//TODO maybe DateTime.UtcNow is repeating too much in the whole project
		[JsonProperty(ISSUED_AT)]
		public DateTime IssuedAt => DateTime.UtcNow;

		[JsonProperty(JTI)]
		public string Jti => Guid.NewGuid().ToString();
	}
}
