using StoreApp.Contracts;
using StoreApp.Contracts.Products.Responses;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces.IServices;
public interface ICategoriesService
{
    Task<Result<IEnumerable<CategoryNameDto>>> GetAllCategoriesAsync();

    Task<Result<Categories>> GetByIdAsync(int id);
    Task<Result<Categories>> CreateAsync(Categories category);
    Task<Result<bool>> DeleteAsync(int id);
}

