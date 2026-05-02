using Microsoft.AspNetCore.Mvc;
using StoreApp.API.ApiHandler;
using StoreApp.Contracts.Products;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces;

namespace StoreApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        return Ok(result);
    }

   [HttpPost("Add")]
    public async Task<IActionResult> AddNewProduct([FromBody] ProductRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            CategoryId = request.CategoryId,
            BrandId = request.BrandId,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            DiscountPercentage = request.DiscountPercentage,
            StockQuantity = request.StockQuantity,
            IsActive = request.IsActive,
            IsFeatured = request.IsFeatured,

            ProductImages = request.ImageUrls
                .Select(url => new ProductImage
                {
                    ImageUrl = url
                }).ToList()
        };

    var result = await _productService.CreateAsync(product);

    if (!result.IsSuccess)
        return BadRequest(result);

    return Ok(result);
}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequest product)
    {
            return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteAsync(id);
        return Ok(result);
    }
}