using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.AspNetCore.ServerSentEvents.Model;
using Demo.AspNetCore.ServerSentEvents.Services;

namespace Demo.AspNetCore.ServerSentEvents.Controllers
{
    public class NotificationsController : Controller
    {
        #region Fields
        private INotificationsService _notificationsService;
        #endregion

        #region Constructor
        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }
        #endregion

        #region Actions
        [ActionName("sse-notifications-receiver")]
        [AcceptVerbs("GET")]
        public IActionResult Receiver()
        {
            return View("Receiver");
        }

        [ActionName("sse-notifications-sender")]
        [AcceptVerbs("GET")]
        public IActionResult Sender()
        {
            return View("Sender", new NotificationsSenderViewModel());
        }

        [ActionName("sse-notifications-sender")]
        [AcceptVerbs("POST")]
        public async Task<IActionResult> Sender(NotificationsSenderViewModel viewModel)
        {
            if (!String.IsNullOrEmpty(viewModel.Notification))
            {
                await _notificationsService.SendNotificationAsync(viewModel.Notification, viewModel.Alert);
            }

            ModelState.Clear();

            return View("Sender", new NotificationsSenderViewModel());
        }
        #endregion
    }
}
