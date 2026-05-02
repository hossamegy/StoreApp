using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces;

public interface ICategoriesRepository
{
    Task<IEnumerable<Categories>> GetAllAsync();
    Task<Categories> GetByIdAsync(int id);
    Task<Categories> CreateAsync(Categories category);
    Task<bool> DeleteAsync(int id);
}

