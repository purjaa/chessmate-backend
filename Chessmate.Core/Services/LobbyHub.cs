using Chessmate.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chessmate.Core.Services;

public class LobbyHub : Hub<ILobbyHubClient>, ILobbyHub
{
}
