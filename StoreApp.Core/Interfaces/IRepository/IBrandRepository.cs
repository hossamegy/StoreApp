using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces.IRepository;

public interface IBrandRepository
{
    Task<IEnumerable<Brands>> GetAllAsync();
    Task<Brands> GetByIdAsync(int id);
    Task<Brands> CreateAsync(Brands category);
    Task<bool> DeleteAsync(int id);
}

