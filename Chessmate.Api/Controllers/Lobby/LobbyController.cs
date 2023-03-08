using Chessmate.Core.Interfaces;
using Chessmate.Core.Services;
using Microsoft.AspNetCore.SignalR;

namespace Chessmate.Api.Controllers.Lobby;

public class LobbyController : BaseController
{
    private readonly IHubContext<LobbyHub, ILobbyHubClient> _lobbyHub;

    public LobbyController(IHubContext<LobbyHub, ILobbyHubClient> lobbyHub)
    {
        _lobbyHub = lobbyHub;
    }
}
