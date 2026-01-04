# Demo.AspNetCore.ServerSentEvents

Application for demonstrating functionality of [Lib.AspNetCore.ServerSentEvents](https://github.com/tpeczek/Lib.AspNetCore.ServerSentEvents).

The application exposes two SSE endpoints:
* `/see-heartbeat` which can be "listened" by navigating to `/sse-heartbeat-receiver.html`. It sends an event every 5s and is implemented through an ugly background thread.
* `/sse-notifications` which can be "listened" by navigating to `/notifications/sse-notifications-receiver`. Sending events to this endpoint can be done by navigating to `/notifications/sse-notifications-sender`.

## Consulting and Professional Services

Do you need help with any of my libraries, or with building features on top of what they provide? I offer paid support and consulting services.

<p align="center">
<img alt="Services provided by Tomasz Pęczek" src="https://github.com/user-attachments/assets/0f9793d8-4766-4a6f-9824-c0e7fec904b2" />
</p>

[![Book an Appointment](https://img.shields.io/badge/%20-Book%20an%20Appointment-%23006BFF?logo=calendly&logoColor=white&style=for-the-badge)](https://calendly.com/tpeczek/30min)
[![Send an Email](https://img.shields.io/badge/%20-Send%20an%20email-%23EA4335?logo=gmail&logoColor=white&style=for-the-badge)](mailto:tpeczek@gmail.com)

## Donating

My blog and open source projects are result of my passion for software development, but they require a fair amount of my personal time. If you got value from any of the content I create, then I would appreciate your support by [sponsoring me](https://github.com/sponsors/tpeczek) (either monthly or one-time).

## Copyright and License

Copyright © 2017 - 2026 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Demo.AspNetCore.ServerSentEvents/blob/master/LICENSE.md)
