using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class WebRepository : IBaseRepository<Web>
	{
		private readonly PharmacyContext _context;
		public WebRepository(PharmacyContext context)
		{
			_context = context;
		}

        public void Add(Web data)
        {
            _context.Webs.Add(data);
        }

        public void Delete(Web data)
        {
            _context.Webs.Remove(data);
        }


        public async Task<IEnumerable<Web>> GetAll()
        {
            var list = await _context.Webs.ToListAsync();
            return list;
        }

        public async Task<Web> GetById(int id)
        {
            var obj = await _context.Webs.FindAsync(id);
            return obj!;
        }

        public async Task<Web> GetbyName(string name)
        {
            var obj = await _context.Webs.FindAsync(name);
            return obj!;
        }

        public async Task Update(Web data)
        {
            if (data != null)
                _context.Webs.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

