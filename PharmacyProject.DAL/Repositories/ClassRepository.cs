using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories
{
	public class ClassRepository : IBaseRepository<Class>
	{
		private readonly PharmacyContext _context;
		public ClassRepository(PharmacyContext context)
		{
			_context = context;
		}

        public async Task Add(Class @class)
        {
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Class @class)
        {
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> GetAll() =>
            await _context.Classes.ToListAsync();

        public async Task<Class> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == id, token);
            return obj!;
        }

        public async Task<Class> GetbyName(string name)
        {
            var obj = await _context.Classes.FindAsync(name);
            return obj!;
        }

        public async Task Update(Class @class)
        {
            if (@class != null)
                _context.Classes.Update(@class);
            await _context.SaveChangesAsync();
        }
    }
}

