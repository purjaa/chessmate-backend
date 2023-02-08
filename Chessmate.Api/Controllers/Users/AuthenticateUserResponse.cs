namespace Chessmate.Api.Controllers.Users;

public class AuthenticateUserResponse
{
    public bool Result { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
