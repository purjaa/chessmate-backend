using Microsoft.AspNetCore.Identity;

namespace Chessmate.Core.Interfaces;

public interface IRegisterUserService
{
    public Task<IdentityResult> RegisterUserAsync(string username, string email, string password);
}
