using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    internal class LocalNotificationsService : NotificationsServiceBase, INotificationsService
    {
        #region Constructor
        public LocalNotificationsService(INotificationsServerSentEventsService notificationsServerSentEventsService)
            : base(notificationsServerSentEventsService)
        { }
        #endregion

        #region Methods
        public Task SendNotificationAsync(string notification, bool alert)
        {
            return SendSseEventAsync(notification, alert);
        }
        #endregion
    }
}
