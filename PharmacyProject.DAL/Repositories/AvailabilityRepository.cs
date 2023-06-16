using System;
using Microsoft.EntityFrameworkCore;
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
        }

        public void Delete(Availability data)
        {
            _context.Availabilities.Remove(data);
        }

        public async Task<IEnumerable<Availability>> GetAvailabilityByDelivery(IEnumerable<Delivery> deliveries)
        {
            var list = await _context.Availabilities.ToListAsync();
            var result = from item in list
                         join delivery in deliveries on item.DeliveryId equals delivery.Id
                         select item;
            return result;
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

        public async Task<Availability> GetById(int id)
        {
            var obj = await _context.Availabilities.FindAsync(id);
            return obj!;
        }

        public async Task<Availability> GetbyName(string name)
        {
            var obj = await _context.Availabilities.FindAsync(name);
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

