using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories
{
	public class AvailabilityRepository : IAvailabilityRepository
	{
        private readonly PharmacyContext _context;
		public AvailabilityRepository(PharmacyContext context)
		{
            _context = context;
		}

        public void Add(Availability data)
        {
            _context.Availabilities.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Availability data)
        {
            _context.Availabilities.Remove(data);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Availability>> GetAvailabilityByDelivery(IEnumerable<int> deliveriesId)
        {
            var list = await _context.Availabilities.Where(x => deliveriesId.Contains(x.DeliveryId)).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Availability>> GetAll()
        {
            var list = await _context.Availabilities.ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Availability>> GetAvailabilitiesByPharmacyId(int pharmacyId)
        {
            var availabilities = await _context.Availabilities.ToListAsync();
            var result = availabilities.Where(avail => avail.PharmacyId == pharmacyId);
            return result;
        }

        public async Task<Availability> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Availabilities.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }


        public async Task Update(Availability data)
        {
            if (data != null)
                _context.Availabilities.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

