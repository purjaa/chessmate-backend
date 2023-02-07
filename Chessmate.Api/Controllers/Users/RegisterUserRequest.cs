using System.ComponentModel.DataAnnotations;

namespace Chessmate.Api.Controllers.Users;

public class RegisterUserRequest
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}
