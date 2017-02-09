# Demo.AspNetCore.ServerSentEvents
Application for demonstrating functionality of [Lib.AspNetCore.ServerSentEvents](https://github.com/tpeczek/Lib.AspNetCore.ServerSentEvents).

The application exposes two SSE endpoints:
* `/see-heartbeat` which can be "listened" by navigating to `/sse-heartbeat-receiver.html`. It sends an event every 5s and is implemented through an ugly background thread.
* `/sse-notifications` which can be "listened" by navigating to `/notifications/sse-notifications-receiver`. Sending events to this endpoint can be done by navigating to `/notifications/sse-notifications-sender`.

## Donating
Support this and my [other projects](https://github.com/tpeczek/) via [Gittip](https://www.gittip.com/tpeczek/).

[![Support via Gittip](https://2.bp.blogspot.com/-hfTLKixXGvw/U-PmH5hGK4I/AAAAAAAAAf8/o94Go42VeZU/s1600/gittip.png)](https://www.gittip.com/tpeczek/)

## Copyright and License
Copyright © 2017 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Demo.AspNetCore.ServerSentEvents/blob/master/LICENSE.md)
