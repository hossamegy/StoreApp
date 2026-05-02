using Microsoft.AspNetCore.Mvc;
using StoreApp.Contracts.Products;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces;

namespace StoreApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _brandService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _brandService.GetByIdAsync(id);
        return Ok(result);
    }

   [HttpPost("Add")]
    public async Task<IActionResult> AddNewProduct([FromBody] BrandRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var brand = new Brands
        {
            Name = request.Name,
        };

    var result = await _brandService.CreateAsync(brand);

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
        var result = await _brandService.DeleteAsync(id);
        return Ok(result);
    }
}