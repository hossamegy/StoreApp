using StoreApp.Contracts;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces;
public interface IBrandService
{
    Task<Result<IEnumerable<Brands>>> GetAllAsync();
    Task<Result<Brands>> GetByIdAsync(int id);
    Task<Result<Brands>> CreateAsync(Brands Brand);
    Task<Result<bool>> DeleteAsync(int id);
}

