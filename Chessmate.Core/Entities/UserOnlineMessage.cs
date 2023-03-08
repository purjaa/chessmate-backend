namespace Chessmate.Core.Entities;

public class UserOnlineMessage
{
    public string Username { get; set; }
    public string ConnectionId { get; set; }

    public UserOnlineMessage(string username, string connectionId)
    {
        Username = username;
        ConnectionId = connectionId;
    }
}
