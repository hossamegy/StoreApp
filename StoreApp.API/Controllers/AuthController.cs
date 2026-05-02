using Microsoft.AspNetCore.Mvc;
using StoreApp.Contracts.Auth;
using StoreApp.Core.Interfaces;

namespace StoreApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(RegisterRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data");

        var result = await _authService.SignUp(request);

        return Ok(result);
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(LoginRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data");

        var result = await _authService.SignIn(request.Email, request.Password);

       

        return Ok(result);
    }

    [HttpPost("AssignRole")]
    public async Task<IActionResult> AssignRoleToUser(AddRoleRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data");

        var result = await _authService.AssignRoleToUser(request);

        return Ok(result);
    }
}