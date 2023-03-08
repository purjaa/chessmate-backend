namespace Chessmate.Core.Interfaces;

public interface IUserStateService
{
    Task CreateUserStateAsync(string username);
    Task SetUserOnlineAsync(string username);
    Task SetUserOfflineAsync(string username);
    Task<List<string>> GetOnlineUsers();
}
