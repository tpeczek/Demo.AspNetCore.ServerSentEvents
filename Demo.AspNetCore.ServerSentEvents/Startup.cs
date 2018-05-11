using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/event-stream" });
            });

            services.AddServerSentEvents();
            services.AddSingleton<IHostedService, HeartbeatService>();

            services.AddServerSentEvents<INotificationsServerSentEventsService, NotificationsServerSentEventsService>();
            services.AddNotificationsService(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseResponseCompression()
                .MapServerSentEvents("/see-heartbeat")
                .MapServerSentEvents("/sse-notifications", serviceProvider.GetService<NotificationsServerSentEventsService>())
                .UseStaticFiles()
                .UseMvc(routes =>
                {
                    routes.MapRoute(name: "default", template: "{controller=Notifications}/{action=sse-notifications-receiver}");
                });
        }
        #endregion
    }
}
