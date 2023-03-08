using Chessmate.Core.Entities;
using Chessmate.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chessmate.Core.Services;

public class LobbyHub : Hub<ILobbyHubClient>, ILobbyHub
{
    private readonly IUserStateService _userStateService;

    public LobbyHub(IUserStateService userStateService)
    {
        _userStateService = userStateService;
    }

    [Authorize]
    public override Task OnConnectedAsync()
    {
        //string username = Context.User.Identity.Name;
        return base.OnConnectedAsync();
    }

    [Authorize]
    public async Task SendUserOnlineMessage(UserOnlineMessage message)
    {
        await _userStateService.SetUserOnlineAsync(message.Username);
        var onlineUsers = await _userStateService.GetOnlineUsers();

        var allOnlineUsersMessage = new AllOnlineUsersMessage(onlineUsers);
        await Clients.All.ReceiveAllOnlineUsersMessage(allOnlineUsersMessage);
    }
}
