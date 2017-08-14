using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Demo.AspNetCore.ServerSentEvents.Model;
using Demo.AspNetCore.ServerSentEvents.Services;
using Lib.AspNetCore.ServerSentEvents;

namespace Demo.AspNetCore.ServerSentEvents.Controllers
{
    public class NotificationsController : Controller
    {
        #region Fields
        private INotificationsServerSentEventsService _serverSentEventsService;
        #endregion

        #region Constructor
        public NotificationsController(INotificationsServerSentEventsService serverSentEventsService)
        {
            _serverSentEventsService = serverSentEventsService;
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
                await _serverSentEventsService.SendEventAsync(new ServerSentEvent
                {
                    Type = viewModel.Alert ? "alert" : null,
                    Data = new List<string>(viewModel.Notification.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
                });
            }

            ModelState.Clear();

            return View("Sender", new NotificationsSenderViewModel());
        }
        #endregion
    }
}
