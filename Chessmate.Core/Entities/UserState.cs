using Chessmate.Core.Interfaces;

namespace Chessmate.Core.Entities;

public class UserState : BaseEntity, IAggregateRoot
{
    public string Username { get; set; }
    public bool IsOnline { get; set; }
    public bool IsAvailable { get; set; }

    public UserState(string username)
    {
        Username = username;
        IsOnline = false;
        IsAvailable = false;
    }
}
