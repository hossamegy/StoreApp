using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoleController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRole(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
            return BadRequest("Role name is required");

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("Role created");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteRole(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest("Role name is required");
            
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
            return NotFound("Role not found");

        var result = await _roleManager.DeleteAsync(role);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("Role deleted");
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateRole(string id, string newName)
    {
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(newName))
            return BadRequest("Role name is required");

        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
            return NotFound("Role not found");

        role.Name = newName;

        var result = await _roleManager.UpdateAsync(role);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("Role updated");
    }

    [HttpGet("all")]
    public IActionResult GetAllRoles()
    {
        var roles = _roleManager.Roles.Select(r => new
        {
            r.Id,
            r.Name
        });

        return Ok(roles);
    }
}
