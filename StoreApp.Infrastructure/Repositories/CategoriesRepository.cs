using Microsoft.EntityFrameworkCore;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces.IRepository;
using StoreApp.Infrastructure.Data;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Categories> _categoriesRepo;


    public CategoriesRepository(AppDbContext context)
    {
        _context = context;
        _categoriesRepo = _context.Set<Categories>();
    }



    public async Task<Categories> CreateAsync(Categories category)
    {
        await _categoriesRepo.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = await _categoriesRepo.Where(c => c.Id == id).ExecuteDeleteAsync();
        return isDeleted > 0;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync()
    {
        return await _categoriesRepo.ToListAsync();
    }

    public Task<Categories> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}