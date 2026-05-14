using StoreApp.Core.Entities.Users;
using StoreApp.Core.Interfaces.IServices;
using StoreApp.Core.Interfaces.IRepository;

namespace StoreApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }
    
    public async Task<User> CreateAsync(string firstName, string lastName, string email, string password)
    {
         throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

}