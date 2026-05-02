using StoreApp.Core.Entities.Users;

public interface IJwtService
{
    string GenerateToken(User user);
}