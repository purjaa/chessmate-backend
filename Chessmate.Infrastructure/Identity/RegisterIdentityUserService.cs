using Chessmate.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Chessmate.Infrastructure.Identity
{
    public class RegisterIdentityUserService : IRegisterUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterIdentityUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(string username, string email, string password)
        {
            var userByEmail = await _userManager.FindByEmailAsync(email);
            var userByUsername = await _userManager.FindByNameAsync(username);
            if (userByEmail is not null || userByUsername is not null)
            {
                throw new ArgumentException($"User with email {email} or username {username} already exists.");
            }

            ApplicationUser user = new()
            {
                Email = email,
                UserName = username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Unable to register user {username} errors: {GetErrorsText(result.Errors)}");
            }

            return result;
        }

        private string GetErrorsText(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(error => error.Description).ToArray());
        }
    }
}
