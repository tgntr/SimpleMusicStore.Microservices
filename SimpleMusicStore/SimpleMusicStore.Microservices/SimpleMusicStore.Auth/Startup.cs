using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.JwtAuthConfiguration;
using SimpleMusicStore.Repositories;
using System;

namespace SimpleMusicStore.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<JwtConfiguration>(JwtPayload());
            services.AddDatabase(DbConnectionString());
            services.AddSingleton<IBus>(RabbitHutch.CreateBus(RabbitMQConnectionString()));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AuthenticationHandler, DevAuthenticator>();
            services.AddTransient<MessageListener>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            appLifetime.ApplicationStarted.Register(() =>
            {
                ApplyMigrations(app);

                app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MessageListener>().ListenForMessages();
            });

            appLifetime.ApplicationStopping.Register(() =>
            {
                app.ApplicationServices.GetService<IBus>().Dispose();
            });
        }

        private static void ApplyMigrations(IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                using (SimpleMusicStoreDbContext db = serviceScope.ServiceProvider.GetRequiredService<SimpleMusicStoreDbContext>())
                {
                    if (db.Database.EnsureCreated())
                    {
                        db.Database.Migrate();
                    }
                }
            }
        }

        private IConfigurationSection JwtPayload() => Configuration.GetSection("JwtPayload");
        private string RabbitMQConnectionString() => Configuration["RabbitMQ:Connection"];
        private string DbConnectionString() => Configuration["Database:Connection"];


    }
}
