using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Repositories;
using System;

namespace SimpleMusicStore.UserActivities
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
            services.AddDatabase("Server=.;Database=SimpleMusicStore;Trusted_Connection=True;");
            services.AddSingleton<IBus>(RabbitHutch.CreateBus("host=localhost;virtualHost=/;username=rabbitmq;password=rabbitmq"));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<MessageListener>();


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
                //using (IServiceScope scope = app.ApplicationServices.CreateScope())
                //{
                //    scope.ServiceProvider.GetRequiredService<MessageListener>().ListenForMessages();
                //}
            });

            appLifetime.ApplicationStopping.Register(() =>
            {
                app.ApplicationServices.GetService<IBus>().Dispose();
            });
        }

        private string DbConnectionString() => Configuration["Database:Connection"];
        private string RabbitMQConnectionString() => Configuration["RabbitMQ:Connection"];
    }
}
