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

        public void Add(OrdDrug ordDrug)
        {
            _context.OrdersDrugs.Add(ordDrug);
            _context.SaveChangesAsync();
        }

        public void Delete(OrdDrug ordDrug)
        {
            _context.OrdersDrugs.Remove(ordDrug);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrdDrug>> GetAll()=>
            await _context.OrdersDrugs.ToListAsync();

        public async Task<OrdDrug> GetById(int id, CancellationToken token)
        {
            var obj = await _context.OrdersDrugs.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<OrdDrug> GetbyName(string name)
        {
            var obj = await _context.OrdersDrugs.FindAsync(name);
            return obj!;
        }

        public async Task Update(OrdDrug ordDrug)
        {
            if (ordDrug != null)
                _context.OrdersDrugs.Update(ordDrug);
            await _context.SaveChangesAsync();
        }
    }
}

