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

        public void Add(Class data)
        {
            _context.Classes.Add(data);
        }

        public void Delete(Class data)
        {
            _context.Classes.Remove(data);
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            var list = await _context.Classes.ToListAsync();
            return list;
        }

        public async Task<Class> GetById(int id)
        {
            var obj = await _context.Classes.FindAsync(id);
            return obj!;
        }

        public async Task<Class> GetbyName(string name)
        {
            var obj = await _context.Classes.FindAsync(name);
            return obj!;
        }

        public async Task Update(Class data)
        {
            if (data != null)
                _context.Classes.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

