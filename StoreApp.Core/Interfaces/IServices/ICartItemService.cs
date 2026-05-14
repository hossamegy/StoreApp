using StoreApp.Core.Entities;

namespace StoreApp.Core.Interfaces.IServices;
public interface ICartItemService
{
    Task<IEnumerable<CartItem>> GetAllCartItemAsync();
    Task<CartItem?> GetByIdAsync(int id);
    Task<CartItem?> GetByEmailAsync(string email);
    Task CreateAsync(CartItem cart);
    Task UpdateAsync(CartItem cart);
    Task DeleteAsync(int id);
}


