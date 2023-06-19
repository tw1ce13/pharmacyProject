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

        public void Add(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChangesAsync();
        }

        public void Delete(Discount discount)
        {
            _context.Discounts.Remove(discount);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Discount>> GetAll()=>
            await _context.Discounts.ToListAsync();

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

        public async Task Update(Discount discount)
        {
            if (discount != null)
                _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();
        }
    }
}


