using Lib.AspNetCore.ServerSentEvents;
using Microsoft.Extensions.Options;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    internal class NotificationsServerSentEventsService : ServerSentEventsService, INotificationsServerSentEventsService
    {
        public NotificationsServerSentEventsService(IOptions<ServerSentEventsServiceOptions<NotificationsServerSentEventsService>> options)
            : base(options.ToBaseServerSentEventsServiceOptions())
        { }
    }
}
