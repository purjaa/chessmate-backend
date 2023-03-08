using Chessmate.Core.Entities;
using Chessmate.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chessmate.Core.Services;

public class LobbyHub : Hub<ILobbyHubClient>, ILobbyHub
{
    private readonly IUserStateService _userStateService;

    public LobbyHub(IUserStateService userStateService)
    {
        _userStateService = userStateService;
    }

    public async Task SendUserOnlineMessage(UserOnlineMessage message)
    {
        await _userStateService.SetUserOnlineAsync(message.Username);
        var onlineUsers = await _userStateService.GetOnlineUsers();

        var allOnlineUsersMessage = new AllOnlineUsersMessage(onlineUsers);
        await Clients.All.ReceiveAllOnlineUsersMessage(allOnlineUsersMessage);
    }
}
