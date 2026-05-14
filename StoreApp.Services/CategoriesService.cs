using AutoMapper;
using FluentValidation;
using StoreApp.Contracts;
using StoreApp.Contracts.Products.Responses;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces.IRepository;
using StoreApp.Core.Interfaces.IServices;

namespace StoreApp.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepo;
    private readonly IMapper _mapper;
    private readonly IValidator<Categories> _validator;
    public CategoriesService(ICategoriesRepository categoriesRepo, IMapper mapper, IValidator<Categories> validator)
    {
        _categoriesRepo = categoriesRepo;
        _mapper = mapper;
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

    public async Task<Result<IEnumerable<CategoryNameDto>>> GetAllCategoriesAsync()
    {
        var categories = await _categoriesRepo.GetAllAsync();
        if (categories == null)
            return Result<IEnumerable<CategoryNameDto>>.Failure("There is no categories in database");
     
        var categoryResponse = _mapper.Map<IEnumerable<CategoryNameDto>>(categories);

        return Result<IEnumerable<CategoryNameDto>>.Success(categoryResponse);    
    }

    public Task<Result<Categories>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}