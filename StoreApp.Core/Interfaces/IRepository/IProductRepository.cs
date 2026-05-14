using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces.IRepository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetProductsByPaginationAsync(int skip, int take);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);

}

