using StoreApp.Core.Entities.Carts;

namespace StoreApp.Core.Interfaces.IServices;
public interface ICartService
{
    Task<IEnumerable<Cart>> GetAllCartsAsync();
    Task<Cart?> GetByIdAsync(int id);
    Task CreateAsync(Cart cart);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(int id); 
}
