using Microsoft.EntityFrameworkCore;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces;
using StoreApp.Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Product> _productRepo;


    public ProductRepository(AppDbContext context)
    {
        _context = context;
        _productRepo = _context.Set<Product>();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        product.CreatedAt = DateTime.UtcNow;
        
        await _productRepo.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var affectedRows = await _productRepo
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return affectedRows > 0;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepo.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productRepo.FindAsync(id);
    }
    public async Task<IEnumerable<Product>> GetProductsByPaginationAsync(int take, int skip)
    {
        return await _productRepo
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        product.UpdatedAt = DateTime.UtcNow;

        _productRepo.Update(product);

        await _context.SaveChangesAsync();
        
    }
}