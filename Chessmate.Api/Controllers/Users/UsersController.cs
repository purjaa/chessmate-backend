using Chessmate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chessmate.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IRegisterUserService _registerUserService;

    public UsersController(IRegisterUserService registerUserService)
    {
        _registerUserService = registerUserService;
    }

    // POST: api/Users/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        if (request.Username == null || request.Email == null || request.Password == null)
        {
            return BadRequest("Insufficient parameters");
        }

        var response = await _registerUserService.RegisterUserAsync(request.Username, request.Email, request.Password);
        return Ok(response);
    }
}
