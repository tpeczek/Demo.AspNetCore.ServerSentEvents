using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lib.AspNetCore.ServerSentEvents;
using Demo.AspNetCore.ServerSentEvents.Services;

namespace Demo.AspNetCore.ServerSentEvents
{
    public class Startup
    {
        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Methods
        public void ConfigureServices(IServiceCollection services)
        {
            // Register default ServerSentEventsService.
            services.AddServerSentEvents();

            // Registers custom ServerSentEventsService which will be used by second middleware, otherwise they would end up sharing connected users.
            services.AddServerSentEvents<INotificationsServerSentEventsService, NotificationsServerSentEventsService>(options =>
            {
                options.ReconnectInterval = 5000;
            });

            // Register cookie based clients identifier provider for Server Sent Events
            // services.AddServerSentEventsClientIdProvider<CookieBasedServerSentEventsClientIdProvider>();

            // Register IServerSentEventsNoReconnectClientsIdsStore backed by memory store.
            // services.AddInMemoryServerSentEventsNoReconnectClientsIdsStore();

            services.AddSingleton<IHostedService, HeartbeatService>();
            services.AddNotificationsService(Configuration);

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/event-stream" });
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression()
                .UseStaticFiles()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    // Set up first Server-Sent Events endpoint.
                    endpoints.MapServerSentEvents("/see-heartbeat");

                    // Set up second (separated) Server-Sent Events endpoint.
                    endpoints.MapServerSentEvents<NotificationsServerSentEventsService>("/sse-notifications");

                    endpoints.MapControllerRoute("default", "{controller=Notifications}/{action=sse-notifications-receiver}");
                });
        }
        #endregion
    }
}
