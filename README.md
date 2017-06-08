# Demo.AspNetCore.ServerSentEvents

Application for demonstrating functionality of [Lib.AspNetCore.ServerSentEvents](https://github.com/tpeczek/Lib.AspNetCore.ServerSentEvents).

The application exposes two SSE endpoints:
* `/see-heartbeat` which can be "listened" by navigating to `/sse-heartbeat-receiver.html`. It sends an event every 5s and is implemented through an ugly background thread.
* `/sse-notifications` which can be "listened" by navigating to `/notifications/sse-notifications-receiver`. Sending events to this endpoint can be done by navigating to `/notifications/sse-notifications-sender`.

## Donating

Lib.AspNetCore.ServerSentEvents is a personal open source project. If Lib.AspNetCore.ServerSentEvents has been helpful to you, consider donating. Donating helps support Lib.AspNetCore.ServerSentEvents.

<a href='https://pledgie.com/campaigns/33551'><img alt='Click here to lend your support to: Lib.AspNetCore.ServerSentEvents and make a donation at pledgie.com !' src='https://pledgie.com/campaigns/33551.png?skin_name=chrome' border='0' ></a>

## Copyright and License

Copyright © 2017 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Demo.AspNetCore.ServerSentEvents/blob/master/LICENSE.md)
