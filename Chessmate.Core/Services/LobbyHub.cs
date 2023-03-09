using Chessmate.Core.Entities;
using Chessmate.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chessmate.Core.Services;

[Authorize]
public class LobbyHub : Hub<ILobbyHubClient>, ILobbyHub
{
    private readonly IUserStateService _userStateService;

    public LobbyHub(IUserStateService userStateService)
    {
        _userStateService = userStateService;
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        try
        {
            string username = Context.User.Identity.Name;
            await _userStateService.SetUserOfflineAsync(username);

            var onlineUsers = await _userStateService.GetOnlineUsers();

            var allOnlineUsersMessage = new AllOnlineUsersMessage(onlineUsers);
            await Clients.All.ReceiveAllOnlineUsersMessage(allOnlineUsersMessage);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendUserOnlineMessage(UserOnlineMessage message)
    {
        await _userStateService.SetUserOnlineAsync(message.Username);
        var onlineUsers = await _userStateService.GetOnlineUsers();

        var allOnlineUsersMessage = new AllOnlineUsersMessage(onlineUsers);
        await Clients.All.ReceiveAllOnlineUsersMessage(allOnlineUsersMessage);
    }
}
