using Chessmate.Core.Interfaces;
using Chessmate.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chessmate.Api.Controllers.Users;

public class UsersController : BaseController
{
    private readonly IRegisterUserService _registerUserService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenClaimsService _tokenClaimsService;
    private readonly IUserStateService _userStateService;

    public UsersController(IRegisterUserService registerUserService,
        SignInManager<ApplicationUser> signInManager,
        ITokenClaimsService tokenClaimsService,
        IUserStateService userStateService)
    {
        _registerUserService = registerUserService;
        _signInManager = signInManager;
        _tokenClaimsService = tokenClaimsService;
        _userStateService = userStateService;
    }

    // POST: api/Users/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        if (request.Username == null || request.Email == null || request.Password == null)
        {
            return BadRequest("Insufficient parameters");
        }

        var result = await _registerUserService.RegisterUserAsync(request.Username, request.Email, request.Password);

        if (result.Succeeded)
        {
            await _userStateService.CreateUserStateAsync(request.Username);
        }

        var response = new AuthenticateUserResponse
        {
            Result = result.Succeeded,
            Username = request.Username
        };

        return Ok(response);
    }

    // POST: api/Users/authenticate
    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticateUserResponse>> Authenticate([FromBody] AuthenticateUserRequest request)
    {
        if (request.Username == null || request.Password == null)
        {
            return BadRequest("Insufficient parameters");
        }

        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        var response = new AuthenticateUserResponse {
            Result = result.Succeeded,
            Username = request.Username
        };

        if (result.Succeeded)
        {
            response.Token = await _tokenClaimsService.GetTokenAsync(request.Username);
        }

        return response;
    }

    [HttpGet("test")]
    [Authorize]
    public async Task<IActionResult> Test()
    {
        var response = new AuthenticateUserResponse();
        response.Result = true;
        return Ok(response);
    }
}
