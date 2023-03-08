using Chessmate.Core.Entities;

namespace Chessmate.Core.Interfaces;

public interface ILobbyHubClient
{
    Task ReceiveUserOnlineMessage(UserOnlineMessage message);
    Task ReceiveAllOnlineUsersMessage(AllOnlineUsersMessage message);
}
