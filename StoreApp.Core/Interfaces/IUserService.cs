using StoreApp.Core.Entities.Users;

namespace StoreApp.Core.Interfaces ;
public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateAsync(string firstName, string lastName, string email, string password);

    Task UpdateAsync(User user);
    Task DeleteAsync(string id);
}
