using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    public interface INotificationsService
    {
        Task SendNotificationAsync(string notification, bool alert);
    }
}
