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

        public async Task Add(Web web)
        {
            _context.Webs.Add(web);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Web web)
        {
            _context.Webs.Remove(web);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Web>> GetAll()=>
            await _context.Webs.ToListAsync();

        public async Task<Web> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Webs.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Web> GetbyName(string name)
        {
            var obj = await _context.Webs.FirstOrDefaultAsync(x=> x.Name == name);
            return obj!;
        }

        public async Task Update(Web web)
        {
            if (web != null)
                _context.Webs.Update(web);
            await _context.SaveChangesAsync();
        }
    }
}

