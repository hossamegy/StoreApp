using StoreApp.Contracts.Auth;

namespace StoreApp.Core.Interfaces;
public interface IAuthService
{
    Task<AuthResult> SignIn(string email, string password);
    Task<AuthResult> SignUp(RegisterRequest registerRequest);
    Task<string> AssignRoleToUser(AddRoleRequest RoleRequest);
}