using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories;

public class RecipeDrugRepository : IBaseRepository<RecipeDrug>
{
    private readonly PharmacyContext _context;
    public RecipeDrugRepository(PharmacyContext context)
    {
        _context = context;
    }


    public async Task Add(RecipeDrug recipeDrug)
    {
        _context.RecipeDrugs.Add(recipeDrug);
        await _context.SaveChangesAsync();
    }


    public async Task Delete(RecipeDrug recipeDrug)
    {
        _context.RecipeDrugs.Remove(recipeDrug);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<RecipeDrug>> GetAll() =>
        await _context.RecipeDrugs.ToListAsync();


    public async Task<RecipeDrug> GetById(int id, CancellationToken token)
    {
        var obj = await _context.RecipeDrugs.FirstOrDefaultAsync(x => x.Id == id, token);
        return obj!;
    }


    public async Task<RecipeDrug> GetbyName(string name)
    {
        var obj = await _context.RecipeDrugs.FindAsync(name);
        return obj!;
    }


    public async Task Update(RecipeDrug recipeDrug)
    {
        if (recipeDrug != null)
            _context.RecipeDrugs.Update(recipeDrug);
        await _context.SaveChangesAsync();
    }
}

