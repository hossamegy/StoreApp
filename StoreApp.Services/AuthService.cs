using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StoreApp.Core.ConfigSettings;
using StoreApp.Core.Entities.Users;
using StoreApp.Contracts.Auth;

using StoreApp.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreApp.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly Jwt _jwt;

    public AuthService(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<Jwt> jwtOptions)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwt = jwtOptions.Value;
    }

    public async Task<AuthResult> SignUp(RegisterRequest registerRequest)
    {
        var existingUser = await _userManager.FindByEmailAsync(registerRequest.Email);

        if (existingUser != null)
            return new AuthResult
            {
                IsAuthenticated = false,
                Message = "Email already existing"
            };

        var user = new User
        {
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Email = registerRequest.Email,
            PhoneNumber = registerRequest.PhoneNumber,
            UserName = registerRequest.Email,
            ProfileImg = registerRequest.ProfileImg,
        };
        
        user.Addresses.Append(new Address()
        {
            City = registerRequest.City,
            Street=registerRequest.Street,
            Building=registerRequest.Building,
            PostalCode=registerRequest.PostalCode,
        });

        var result = await _userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            return new AuthResult
            {
                IsAuthenticated = false,
                Message = errors
            };
        }

        var token = await GenerateToken(user);

        return new AuthResult
        {
            IsAuthenticated = true,
            Message = "Sign up successful",
            Token = token
        };
    }

    public async Task<AuthResult> SignIn(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return new AuthResult
            {
                IsAuthenticated = false,
                Message = "Invalid email or password"
            };
        }

        var isValidPassword = await _userManager.CheckPasswordAsync(user, password);

        if (!isValidPassword)
        {
            return new AuthResult
            {
                IsAuthenticated = false,
                Message = "Invalid email or password"
            };
        }

        var token = await GenerateToken(user);

        return new AuthResult
        {
            IsAuthenticated = true,
            Message = "Sign in successful",
            Token = token
        };
    }

    public async Task<string> AssignRoleToUser(AddRoleRequest addRoleRequest)
    {
        var user = await _userManager.FindByIdAsync(addRoleRequest.UserId);
        
        if (user == null || !await _roleManager.RoleExistsAsync(addRoleRequest.Role))
        {
            return "Ivalid User Or Role name";
        }

        if (await _userManager.IsInRoleAsync(user, addRoleRequest.Role))
        {
            return "User already assigned to this role";
        }

        var result = await _userManager.AddToRoleAsync(user, addRoleRequest.Role);
        
        if (!result.Succeeded)
        {
            return "Failed to assign role";
        }

        return "Role assigned successfully";
    }

    public async Task<string> GenerateToken(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? "")
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwt.Key)
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwt.DurationInDays),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}