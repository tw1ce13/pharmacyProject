using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories
{
	public class DeliveryRepository : IDeliveryRepository
	{
        private readonly PharmacyContext _context;
		public DeliveryRepository(PharmacyContext context)
		{
            _context = context;
		}

        public void Add(Delivery data)
        {
            _context.Deliveries.Add(data);
        }

        public void Delete(Delivery data)
        {
            _context.Deliveries.Remove(data);
        }


        public async Task<IEnumerable<Delivery>> GetAll()
        {
            var list = await _context.Deliveries.ToListAsync();
            return list;
        }

        public async Task<Delivery> GetById(int id)
        {
            var obj = await _context.Deliveries.FindAsync(id);
            return obj!;
        }

        public async Task<Delivery> GetbyName(string name)
        {
            var obj = await _context.Deliveries.FindAsync(name);
            return obj!;
        }

        public async Task<IEnumerable<Delivery>> GetFresh()
        {
            var list = await _context.Deliveries.ToListAsync();
            var result = list.Where(delivery => delivery.ExpirationData >= DateTime.Now);
            return result;
        }

        public async Task Update(Delivery data)
        {
            if (data != null)
                _context.Deliveries.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

