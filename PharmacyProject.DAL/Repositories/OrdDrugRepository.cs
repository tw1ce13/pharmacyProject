using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class OrdDrugRepository : IBaseRepository<OrdDrug>
	{
		private readonly PharmacyContext _context;
		public OrdDrugRepository(PharmacyContext context)
		{
            _context = context;
		}

        public void Add(OrdDrug data)
        {
            _context.OrdersDrugs.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(OrdDrug data)
        {
            _context.OrdersDrugs.Remove(data);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrdDrug>> GetAll()
        {
            var list = await _context.OrdersDrugs.ToListAsync();
            return list;
        }

        public async Task<OrdDrug> GetById(int id)
        {
            var obj = await _context.OrdersDrugs.FindAsync(id);
            return obj!;
        }

        public async Task<OrdDrug> GetbyName(string name)
        {
            var obj = await _context.OrdersDrugs.FindAsync(name);
            return obj!;
        }

        public async Task Update(OrdDrug data)
        {
            if (data != null)
                _context.OrdersDrugs.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

