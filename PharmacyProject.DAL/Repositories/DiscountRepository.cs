using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories
{
	public class DiscountRepository : IBaseRepository<Discount>
	{
        private readonly PharmacyContext _context;
        public DiscountRepository(PharmacyContext context)
        {
            _context = context;
        }

        public void Add(Discount data)
        {
            _context.Discounts.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Discount data)
        {
            _context.Discounts.Remove(data);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Discount>> GetAll()
        {
            var list = await _context.Discounts.ToListAsync();
            return list;
        }

        public async Task<Discount> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Discount> GetbyName(string name)
        {
            var obj = await _context.Discounts.FindAsync(name);
            return obj!;
        }

        public async Task Update(Discount data)
        {
            if (data != null)
                _context.Discounts.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}


