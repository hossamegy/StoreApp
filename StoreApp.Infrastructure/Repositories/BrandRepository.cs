using Microsoft.EntityFrameworkCore;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Interfaces.IRepository;
using StoreApp.Infrastructure.Data;

public class BrandRepository : IBrandRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Brands> _brandRepo;


    public BrandRepository(AppDbContext context)
    {
        _context = context;
        _brandRepo = _context.Set<Brands>();
    }



    public async Task<Brands> CreateAsync(Brands brand)
    {
        await _brandRepo.AddAsync(brand);
        await _context.SaveChangesAsync();

        return brand;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = await _brandRepo.Where(c => c.Id == id).ExecuteDeleteAsync();
        return isDeleted > 0;
    }

    public async Task<IEnumerable<Brands>> GetAllAsync()
    {
        return await _brandRepo.ToListAsync();
    }

    public Task<Brands> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

}