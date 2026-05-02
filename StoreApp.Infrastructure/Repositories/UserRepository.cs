using Microsoft.EntityFrameworkCore;
using StoreApp.Core.Entities.Users;
using StoreApp.Core.Interfaces;
using StoreApp.Infrastructure.Data;

namespace StoreApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<User> _userRepo;

    public UserRepository(AppDbContext context)
    {
        _context = context;
        _userRepo = _context.Set<User>();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepo.ToListAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _userRepo.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var user = await _userRepo.FindAsync(id);

        if (user == null) return false;

        _userRepo.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepo
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _userRepo.FindAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        _userRepo.Update(user);
        await _context.SaveChangesAsync();
    }
}