using Microsoft.EntityFrameworkCore;
using StoreApp.Core.Entities.Carts;
using StoreApp.Core.Interfaces.IRepository;
using StoreApp.Infrastructure.Data;

namespace StoreApp.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Cart> _cartRepo;

    public CartRepository(AppDbContext context)
    {
        _context = context;
        _cartRepo = _context.Set<Cart>();
    }

    public async Task CreateAsync(Cart cart)
    {
        cart.CreatedAt = DateTime.UtcNow;

        await _cartRepo.AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cart = await _cartRepo.FindAsync(id);

        if (cart == null) return false;

        _cartRepo.Remove(cart);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Cart>> GetAllCartsAsync()
    {
        return await _cartRepo.ToListAsync();
    }

    public async Task<Cart?> GetByIdAsync(int id)
    {
        return await _cartRepo.FindAsync(id);
    }

    public async Task UpdateAsync(Cart cart)
    {
        cart.UpdatedAt = DateTime.UtcNow;

        _cartRepo.Update(cart);
        await _context.SaveChangesAsync();
    }
    
}