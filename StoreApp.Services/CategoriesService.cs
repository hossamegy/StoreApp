using FluentValidation;
using StoreApp.Contracts;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces;

namespace StoreApp.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepo;
    private readonly IValidator<Categories> _validator;
    public CategoriesService(ICategoriesRepository categoriesRepo, IValidator<Categories> validator)
    {
        _categoriesRepo = categoriesRepo;
        _validator = validator;
    }

    public async Task<Result<Categories>> CreateAsync(Categories category)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList();
                    
                return Result<Categories>.Failure("Validation failed", errors);  
            }
              
            var created = await _categoriesRepo.CreateAsync(category);

            return Result<Categories>.Success(created, "Category created successfully");
        }
        catch (Exception ex)
        {
            return Result<Categories>.Failure(
                "Error creating category",
                new List<string> { ex.Message });
        }
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        if (id < 0)
            return Result<bool>.Failure("Id is invalid");

            try
            {
                var isDeleted = await _categoriesRepo.DeleteAsync(id);

                if (!isDeleted)
                    return Result<bool>.Failure("There is no product with this id");

                    return Result<bool>.Success(true, "Product deleted successfully");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(
                    "Something went wrong while deleting product",
                    new List<string> { ex.Message });
            }    
    }

    public async Task<Result<IEnumerable<Categories>>> GetAllAsync()
    {
        var categories = await _categoriesRepo.GetAllAsync();
        if (categories == null)
            return Result<IEnumerable<Categories>>.Failure("There is no categories in database");
 
        return Result<IEnumerable<Categories>>.Success(categories);    
    }

    public Task<Result<Categories>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}