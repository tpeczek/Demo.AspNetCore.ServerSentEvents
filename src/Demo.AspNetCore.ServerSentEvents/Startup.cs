using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Lib.AspNetCore.ServerSentEvents;
using Demo.AspNetCore.ServerSentEvents.Services;

namespace Demo.AspNetCore.ServerSentEvents
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServerSentEvents();
            services.AddServerSentEvents<INotificationsServerSentEventsService, NotificationsServerSentEventsService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapServerSentEvents("/see-heartbeat")
                .MapServerSentEvents("/sse-notifications", serviceProvider.GetService<NotificationsServerSentEventsService>())
                .UseStaticFiles()
                .UseMvc(routes =>
                {
                    routes.MapRoute(name: "default", template: "{controller=Notifications}/{action=sse-notifications-receiver}");
                });

            // Only for demo purposes, don't do this kind of thing to your production
            IServerSentEventsService serverSentEventsService = serviceProvider.GetService<IServerSentEventsService>();
            System.Threading.Thread eventsHeartbeatThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                while (true)
                {
                    serverSentEventsService.SendEventAsync($"Demo.AspNetCore.ServerSentEvents Heartbeat ({DateTime.UtcNow} UTC)").Wait();
                    System.Threading.Thread.Sleep(5000);
                }
            }));
            eventsHeartbeatThread.Start();
        }
    }
}
