using StoreApp.Core.Entities.Carts;

namespace StoreApp.Core.Interfaces;
public interface ICartRepository
{
    Task<IEnumerable<Cart>> GetAllCartsAsync();
    Task<Cart?> GetByIdAsync(int id);
    Task CreateAsync(Cart cart);
    Task UpdateAsync(Cart cart);
    Task<bool> DeleteAsync(int id);
}   

