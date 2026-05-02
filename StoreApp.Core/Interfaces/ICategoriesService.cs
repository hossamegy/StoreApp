using StoreApp.Contracts;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces;
public interface ICategoriesService
{
    Task<Result<IEnumerable<Categories>>> GetAllAsync();
    Task<Result<Categories>> GetByIdAsync(int id);
    Task<Result<Categories>> CreateAsync(Categories category);
    Task<Result<bool>> DeleteAsync(int id);
}

