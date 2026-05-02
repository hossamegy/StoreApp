using FluentValidation;
using StoreApp.Contracts;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces;

namespace StoreApp.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepo;
    private readonly IValidator<Brands> _validator;
    public BrandService(IBrandRepository brandRepo, IValidator<Brands> validator)
    {
        _brandRepo = brandRepo;
        _validator = validator;
    }

    public async Task<Result<Brands>> CreateAsync(Brands brand)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(brand);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();
                    
                return Result<Brands>.Failure("Validation failed", errors);  
            }
              
            var created = await _brandRepo.CreateAsync(brand);

            return Result<Brands>.Success(created, "Brand created successfully");
        }
        catch (Exception ex)
        {
            return Result<Brands>.Failure(
                "Error creating brand",
                new List<string> { ex.Message });
        }
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        if (id < 0)
            return Result<bool>.Failure("Id is invalid");

            try
            {
                var isDeleted = await _brandRepo.DeleteAsync(id);

                if (!isDeleted)
                    return Result<bool>.Failure("There is no brand with this id");

                    return Result<bool>.Success(true, "Brand deleted successfully");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(
                    "Something went wrong while deleting brand",
                    new List<string> { ex.Message });
            }    
    }

    public async Task<Result<IEnumerable<Brands>>> GetAllAsync()
    {
        var brands = await _brandRepo.GetAllAsync();
        if (brands == null)
            return Result<IEnumerable<Brands>>.Failure("There is no brands in database");
 
        return Result<IEnumerable<Brands>>.Success(brands);    
    }

    public Task<Result<Brands>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}