# Chessmate-backend

Chessmate is a web application for playing chess online, a work in progress.

## Description

Chessmate-backend is written using Visual Studio 2022, utilizing ASP.NET Core 6, Entity Framework 6 and SignalR for real time communication between the client and the server. Chessmate-backend follows so called Clean Architecture which is explained here: https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures. The purpose of the project is to learn and to have fun doing so.

## Installation

In Visual Studio 2022 open Package Manager Console and choose the Chessmate.Infrastructure project as the active one. Type in

```
Update-Database -Context AppIdentityDbContext
Update-Database -Context UserStateContext
```
to create the database tables according to the migrations created in the project. After this everything should be set and the backedn can be started from Visual Studio.