using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleMusicStore.JwtAuthConfiguration
{
    public static class JwtSetup
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfigurationSection config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = config.JwtConfiguration().ValidationParameters();
                });
        }

        private static JwtConfiguration JwtConfiguration(this IConfigurationSection config)
            => config.Get<JwtConfiguration>();
    }
}
