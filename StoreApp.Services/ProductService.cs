using AutoMapper;
using FluentValidation;
using StoreApp.Contracts;
using StoreApp.Contracts.Products.Responses;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces.IRepository;
using StoreApp.Core.Interfaces.IServices;

namespace StoreApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepo;
    private readonly IMapper _mapper;
    private readonly IValidator<Product> _validator;
    public ProductService(IProductRepository productRepo, IMapper mapper, IValidator<Product> validator)
    {
        _productRepo = productRepo;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Product>> CreateAsync(Product product)
    {
        if (product == null)
            return Result<Product>.Failure("Product is null");

        var validationResult = await _validator.ValidateAsync(product);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            return Result<Product>.Failure("Validation failed", errors);
        }

        try
        {
            var result = await _productRepo.CreateAsync(product);

            return Result<Product>.Success(result, "Product created successfully");
        }
        catch (Exception ex)
        {

            var errors = new List<string> { ex.Message };
            return Result<Product>.Failure("Something went wrong while creating product", errors);
        }
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        if (id < 0)
            return Result<bool>.Failure("Id is invalid");

        try
        {
            var isDeleted = await _productRepo.DeleteAsync(id);

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

    public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync()
    {
        var products = await _productRepo.GetAllProductsAsync();
        if (products == null)
            return Result<IEnumerable<Product>>.Failure("There is no product in database");
 
        return Result<IEnumerable<Product>>.Success(products);
    }

    public async Task<Result<Product>> GetByIdAsync(int id)
    {
        try
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
                return Result<Product>.Failure("There is no product with this id");

            return Result<Product>.Success(product);

        }
        catch (Exception ex)
        {
             return Result<Product>.Failure(
                 "Something went wrong while retrieve product",
                new List<string>{ ex.Message });
        }
        }
    public async Task<Result<IEnumerable<ProductResponse>>> GetProductsByPaginationAsync(int skip, int take)
    {
        if (skip < 0)
            skip = 0;

        if (take <= 0)
            take = 10;

        try
        {
            var products = await _productRepo.GetProductsByPaginationAsync(skip, take);
        var productResponse = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Result<IEnumerable<ProductResponse>>.Success(productResponse, "Products retrieved successfully");
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ProductResponse>>.Failure(
                "Error occurred while retrieving products",
                new List<string> { ex.Message });
        }
    }    

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}