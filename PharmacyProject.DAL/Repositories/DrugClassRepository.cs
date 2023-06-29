using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories;

public class DrugClassRepository : IBaseRepository<DrugClass>
{
    private readonly PharmacyContext _context;
    public DrugClassRepository(PharmacyContext context)
    {
        _context = context;
    }


    public async Task Add(DrugClass @class)
    {
        _context.Classes.Add(@class);
        await _context.SaveChangesAsync();
    }


    public async Task Delete(DrugClass @class)
    {
        _context.Classes.Remove(@class);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<DrugClass>> GetAll() =>
        await _context.Classes.ToListAsync();


    public async Task<DrugClass> GetById(int id, CancellationToken token)
    {
        var obj = await _context.Classes.FirstOrDefaultAsync(x => x.Id == id, token);
        return obj!;
    }


    public async Task<DrugClass> GetbyName(string name)
    {
        var obj = await _context.Classes.FindAsync(name);
        return obj!;
    }


    public async Task Update(DrugClass @class)
    {
        if (@class != null)
            _context.Classes.Update(@class);
        await _context.SaveChangesAsync();
    }
}

