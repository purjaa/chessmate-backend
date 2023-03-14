# Chessmate-backend

Chessmate is a web application for playing chess online, a work in progress.

## Description

Chessmate-backend is written using Visual Studio 2022, utilizing ASP.NET Core 6, Entity Framework 6 and SignalR for real time communication between the client and the server. Chessmate-backend is essentially a REST and SgnalR (WebSockets) API which will handle the chess application's user related services as well as the rules and gameplay for the chess matches. It follows so called Clean Architecture which is explained here: https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures. The purpose of the project is to learn and to have fun doing so.

## Installation

In Visual Studio 2022 open Package Manager Console and choose the Chessmate.Infrastructure project as the active one. Type in

```
Update-Database -Context AppIdentityDbContext
Update-Database -Context UserStateContext
```
to create the database tables according to the migrations created in the project. After this everything should be set and the backend can be started from Visual Studio.

## Current features
- user registration and logging in, using JSON Web Token based authentication 
- base for SignalR communication (LobbyService which can be used to track online / offline users)

## TODO
For the MVP there's still a lot to do:
- everything related to the chess gameplay :)
- everything related to tests
- deployment to a real server / cloud

For the future, if not to MVP:
- upgrade to ASP.NET Core 7 and Entity Framework 7
- many features like player rankings, friend system, the possibility to go through previous games step by step, ...