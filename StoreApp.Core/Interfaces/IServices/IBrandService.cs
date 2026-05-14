using StoreApp.Contracts;
using StoreApp.Contracts.Products.Responses;

using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Interfaces.IServices;
public interface IBrandService
{
    Task<Result<IEnumerable<BrandNameDto>>> GetAllBrandAsync();
    Task<Result<Brands>> GetByIdAsync(int id);
    Task<Result<Brands>> CreateAsync(Brands Brand);
    Task<Result<bool>> DeleteAsync(int id);
}

