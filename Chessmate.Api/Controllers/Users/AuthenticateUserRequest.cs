using System.ComponentModel.DataAnnotations;

namespace Chessmate.Api.Controllers.Users;

public class AuthenticateUserRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}
