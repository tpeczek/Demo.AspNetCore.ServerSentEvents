using System;
using Microsoft.AspNetCore.Http;
using Lib.AspNetCore.ServerSentEvents;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    internal class CookieBasedServerSentEventsClientIdProvider : IServerSentEventsClientIdProvider
    {
        private const string COOKIE_NAME = ".ServerSentEvents.Guid";

        public Guid AcquireClientId(HttpContext context)
        {
            Guid clientId;

            string cookieValue = context.Request.Cookies[COOKIE_NAME];
            if (String.IsNullOrWhiteSpace(cookieValue) || !Guid.TryParse(cookieValue, out clientId))
            {
                clientId = Guid.NewGuid();

                context.Response.Cookies.Append(COOKIE_NAME, clientId.ToString());
            }

            return clientId;
        }

        public void ReleaseClientId(Guid clientId, HttpContext context)
        {
            context.Response.Cookies.Delete(COOKIE_NAME);
        }
    }
}
