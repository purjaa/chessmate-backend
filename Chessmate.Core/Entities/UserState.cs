using Chessmate.Core.Interfaces;

namespace Chessmate.Core.Entities;

public class UserState : BaseEntity, IAggregateRoot
{
    public string Username { get; set; }
    public bool IsOnline { get; set; }
    public bool IsOccupied { get; set; }

    public UserState(string username)
    {
        Username = username;
        IsOnline = false;
        IsOccupied = false;
    }
}
