# FootballApp

FootballApp is a application built with [Blazor](https://blazor.net) framework using the client-side hosting model with WebAssembly in the browser invoking .NET Core REST APIs secured by a JWT service. For authenticated pages and APIs, use the credentials (Username: cancanbolat / Password: 123456789).

* Endpoints: Get teams, positions, players, player details, create player

# Features
* Onion Architecture | CQRS & MediatR & AutoMapper
* Javascript Web Token (JWT) authentication.
* PostgreSQL
* Redis Cache
* SignalR 

# Open Source Used

* [AutoMapper](https://github.com/AutoMapper/AutoMapper) for object-object mappings.
* [BlazorStorage](https://github.com/cloudcrate/BlazorStorage) for local and session storage in the browser.
* [MediatR](https://github.com/jbogard/MediatR) for supports request/response, commands, queries, notifications and events.
