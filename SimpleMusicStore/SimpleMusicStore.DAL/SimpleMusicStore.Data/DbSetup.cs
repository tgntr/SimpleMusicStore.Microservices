using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleMusicStore.Data
{
    public static class DbSetup
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SimpleMusicStoreDbContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(connectionString));
        }
    }
}
