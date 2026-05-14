using Microsoft.AspNetCore.Mvc;
using StoreApp.Contracts.Products.Requests;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces.IServices;

namespace StoreApp.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _categoriesService.GetAllCategoriesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoriesService.GetByIdAsync(id);
        return Ok(result);
    }

   [HttpPost("Add")]
    public async Task<IActionResult> AddNewProduct([FromBody] CategoryRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = new Categories
        {
            Name = request.Name,
        };

    var result = await _categoriesService.CreateAsync(category);

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
        var result = await _categoriesService.DeleteAsync(id);
        return Ok(result);
    }
}