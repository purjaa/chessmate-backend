using Chessmate.Core.Entities;
using Chessmate.Core.Interfaces;

namespace Chessmate.Core.Services;

public class UserStateService : IUserStateService
{
    private readonly IRepository<UserState> _userStateRepository;

    public UserStateService(IRepository<UserState> userStateRepository)
    {
        _userStateRepository = userStateRepository;
    }

    public async Task CreateUserStateAsync(string username)
    {
        UserState userState = new UserState(username);
        await _userStateRepository.AddAsync(userState);
    }
}
