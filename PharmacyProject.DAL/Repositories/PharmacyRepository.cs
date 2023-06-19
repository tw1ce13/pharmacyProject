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

        public void Add(Pharmacy pharmacy)
        {
            _context.Pharmacies.Add(pharmacy);
            _context.SaveChangesAsync();
        }

        public void Delete(Pharmacy pharmacy)
        {
            _context.Pharmacies.Remove(pharmacy);
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

        public async Task<Pharmacy> GetbyName(string address)
        {
            var obj = await _context.Pharmacies.FirstOrDefaultAsync(x=> x.Address == address);
            return obj!;
        }

        public async Task Update(Pharmacy pharmacy)
        {
            if (pharmacy != null)
                _context.Pharmacies.Update(pharmacy);
            await _context.SaveChangesAsync();
        }
    }
}

