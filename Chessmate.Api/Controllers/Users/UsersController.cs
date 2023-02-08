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

    public UsersController(IRegisterUserService registerUserService,
        SignInManager<ApplicationUser> signInManager,
        ITokenClaimsService tokenClaimsService)
    {
        _registerUserService = registerUserService;
        _signInManager = signInManager;
        _tokenClaimsService = tokenClaimsService;
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

    // POST: api/Users/authenticate
    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticateUserResponse>> Authenticate([FromBody] AuthenticateUserRequest request)
    {
        if (request.Username == null || request.Password == null)
        {
            return BadRequest("Insufficient parameters");
        }

        var response = new AuthenticateUserResponse();
        var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

        response.Result = result.Succeeded;
        response.Username = request.Username;

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
