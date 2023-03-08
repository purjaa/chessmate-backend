namespace Chessmate.Core.Entities;

public class UserOnlineMessage
{
    public string Username { get; set; }

    public UserOnlineMessage(string username)
    {
        Username = username;
    }
}
