using StoreApp.Contracts;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces;
public interface IProductService
{
    Task<Result<IEnumerable<Product>>> GetAllProductsAsync();
    Task<Result<IEnumerable<Product>>> GetProductsByPaginationAsync(int skip, int take);
    Task<Result<Product>> GetByIdAsync(int id);
    Task<Result<Product>> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task<Result<bool>> DeleteAsync(int id);

}

