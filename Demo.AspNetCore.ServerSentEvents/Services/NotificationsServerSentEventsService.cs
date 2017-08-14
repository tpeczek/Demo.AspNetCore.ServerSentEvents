using Lib.AspNetCore.ServerSentEvents;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    public class NotificationsServerSentEventsService : ServerSentEventsService, INotificationsServerSentEventsService
    {
        public NotificationsServerSentEventsService()
        {
            ChangeReconnectIntervalAsync(5000);
        }
    }
}
