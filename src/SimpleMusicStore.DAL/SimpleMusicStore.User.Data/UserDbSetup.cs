using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleMusicStore.User.Data
{
    public static class UserDbSetup
    {
        public static void AddUserDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SimpleMusicStoreUserDataContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString));
        }
    }
}
