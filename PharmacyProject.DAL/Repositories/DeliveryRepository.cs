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

        public void Add(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChangesAsync();
        }

        public void Delete(Delivery delivery)
        {
            _context.Deliveries.Remove(delivery);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Delivery>> GetAll()=>
            await _context.Deliveries.ToListAsync();

        public async Task<Delivery> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Delivery> GetbyName(string name)
        {
            var obj = await _context.Deliveries.FindAsync(name);
            return obj!;
        }

        public async Task<IEnumerable<Delivery>> GetFresh()
        {
            var list = await _context.Deliveries.Where(x=>x.ExpirationDate>=DateTime.UtcNow).ToListAsync();
            return list;
        }

        public async Task Update(Delivery delivery)
        {
            if (delivery != null)
                _context.Deliveries.Update(delivery);
            await _context.SaveChangesAsync();
        }
    }
}

