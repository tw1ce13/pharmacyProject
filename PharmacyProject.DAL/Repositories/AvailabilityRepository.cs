using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories;

public class AvailabilityRepository : IAvailabilityRepository
{
    private readonly PharmacyContext _context;
    public AvailabilityRepository(PharmacyContext context)
    {
        _context = context;
    }


    public async Task Add(Availability availability)
    {
        _context.Availabilities.Add(availability);
        await _context.SaveChangesAsync();
    }


    public async Task Delete(Availability availability)
    {
        _context.Availabilities.Remove(availability);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Availability>> GetAvailabilitiesByDelivery(IEnumerable<int> deliveriesId)
    {
        var list = await _context.Availabilities.Where(x => deliveriesId.Contains(x.DeliveryId)).ToListAsync();
        return list;
    }


    public async Task<IEnumerable<Availability>> GetAll() =>
        await _context.Availabilities.ToListAsync();


    public async Task<IEnumerable<Availability>> GetAvailabilitiesByPharmacyId(int pharmacyId)
    {
        var availabilities = await _context.Availabilities.Where(x => x.PharmacyId == pharmacyId).ToListAsync();
        return availabilities;
    }


    public async Task<Availability> GetById(int id, CancellationToken token)
    {
        var obj = await _context.Availabilities.FirstOrDefaultAsync(x => x.Id == id, token);
        return obj!;
    }


    public async Task Update(Availability availability)
    {
        if (availability != null)
            _context.Availabilities.Update(availability);
        await _context.SaveChangesAsync();
    }
}

