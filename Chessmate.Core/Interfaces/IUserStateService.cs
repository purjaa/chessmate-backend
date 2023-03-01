namespace Chessmate.Core.Interfaces;

public interface IUserStateService
{
    Task CreateUserStateAsync(string username);
}
