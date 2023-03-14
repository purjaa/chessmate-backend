using Ardalis.GuardClauses;
using Chessmate.Core.Entities;
using Chessmate.Core.Interfaces;
using Chessmate.Core.Specifications;
using System;

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

    public async Task SetUserOnlineAsync(string username)
    {
        var userStateSpecification = new UserStateSpecification(username);
        var userState = await _userStateRepository.FirstOrDefaultAsync(userStateSpecification);

        Guard.Against.Null(userState, nameof(userState));

        userState.IsOnline = true;
        userState.IsAvailable = true;
        await _userStateRepository.UpdateAsync(userState);
    }

    public async Task SetUserOfflineAsync(string username)
    {
        var userStateSpecification = new UserStateSpecification(username);
        var userState = await _userStateRepository.FirstOrDefaultAsync(userStateSpecification);

        Guard.Against.Null(userState, nameof(userState));

        userState.IsOnline = false;
        userState.IsAvailable = false;
        await _userStateRepository.UpdateAsync(userState);
    }

    public async Task<List<string>> GetOnlineUsers()
    {
        var onlineUsersSpecification = new OnlineUsersSpecification();
        var onlineUsers = await _userStateRepository.ListAsync(onlineUsersSpecification);

        var users = onlineUsers.Select(onlineUser => onlineUser.Username).ToList();
        return users;
    }
}
