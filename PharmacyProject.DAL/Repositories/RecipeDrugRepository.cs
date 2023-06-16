using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class RecipeDrugRepository : IBaseRepository<RecipeDrug>
	{
		private readonly PharmacyContext _context;
		public RecipeDrugRepository(PharmacyContext context)
		{
			_context = context;
		}

        public void Add(RecipeDrug data)
        {
            _context.RecipeDrugs.Add(data);
        }

        public void Delete(RecipeDrug data)
        {
            _context.RecipeDrugs.Remove(data);
        }


        public async Task<IEnumerable<RecipeDrug>> GetAll()
        {
            var list = await _context.RecipeDrugs.ToListAsync();
            return list;
        }

        public async Task<RecipeDrug> GetById(int id)
        {
            var obj = await _context.RecipeDrugs.FindAsync(id);
            return obj!;
        }

        public async Task<RecipeDrug> GetbyName(string name)
        {
            var obj = await _context.RecipeDrugs.FindAsync(name);
            return obj!;
        }

        public async Task Update(RecipeDrug data)
        {
            if (data != null)
                _context.RecipeDrugs.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

