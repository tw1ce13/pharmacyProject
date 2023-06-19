using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class PharmacyRepository : IBaseRepository<Pharmacy>
	{
		private readonly PharmacyContext _context;
		public PharmacyRepository(PharmacyContext context)
		{
			_context = context;
		}

        public void Add(Pharmacy data)
        {
            _context.Pharmacies.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Pharmacy data)
        {
            _context.Pharmacies.Remove(data);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
            var list = await _context.Pharmacies.ToListAsync();
            return list;
        }

        public async Task<Pharmacy> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Pharmacies.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Pharmacy> GetbyName(string name)
        {
            var obj = await _context.Pharmacies.FindAsync(name);
            return obj!;
        }

        public async Task Update(Pharmacy data)
        {
            if (data != null)
                _context.Pharmacies.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

