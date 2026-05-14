using StoreApp.Contracts.Products.Responses;
using StoreApp.Core.Entities.Products;
using StoreApp.Contracts;

namespace StoreApp.Core.Interfaces.IServices;
public interface IProductService
{
    Task<Result<IEnumerable<Product>>> GetAllProductsAsync();
    Task<Result<IEnumerable<ProductResponse>>> GetProductsByPaginationAsync(int skip, int take);
    Task<Result<Product>> GetByIdAsync(int id);
    Task<Result<Product>> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task<Result<bool>> DeleteAsync(int id);

}

