using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Core.Entities.Users;

namespace StoreApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController : ControllerBase
{

    private readonly UserManager<User> _userManager;
    public UserController(UserManager<User> userManager)
    {
       _userManager = userManager; 
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users =  _userManager.Users.ToList();
        return Ok(users);
    }

}