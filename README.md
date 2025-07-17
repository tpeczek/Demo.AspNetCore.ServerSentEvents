# Demo.AspNetCore.ServerSentEvents

Application for demonstrating functionality of [Lib.AspNetCore.ServerSentEvents](https://github.com/tpeczek/Lib.AspNetCore.ServerSentEvents).

The application exposes two SSE endpoints:
* `/see-heartbeat` which can be "listened" by navigating to `/sse-heartbeat-receiver.html`. It sends an event every 5s and is implemented through an ugly background thread.
* `/sse-notifications` which can be "listened" by navigating to `/notifications/sse-notifications-receiver`. Sending events to this endpoint can be done by navigating to `/notifications/sse-notifications-sender`.

## Consulting and Professional Services

Do you need help with any of my libraries, or with building features on top of what they provide? What about ASP.NET Core architecture, Azure architecture, or DevOps? I offer consulting and development services.

[![Book an Appointment](https://img.shields.io/badge/%20-Book%20an%20Appointment-%23006BFF?logo=calendly&logoColor=white&style=for-the-badge)](https://calendly.com/tpeczek/30min)
[![Send an Email](https://img.shields.io/badge/%20-Send%20an%20email-%23EA4335?logo=gmail&logoColor=white&style=for-the-badge)](mailto:tpeczek@gmail.com)

## Donating

My blog and open source projects are result of my passion for software development, but they require a fair amount of my personal time. If you got value from any of the content I create, then I would appreciate your support by [sponsoring me](https://github.com/sponsors/tpeczek) (either monthly or one-time).

## Copyright and License

Copyright © 2017 - 2025 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Demo.AspNetCore.ServerSentEvents/blob/master/LICENSE.md)
