using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Repositories
{
	public class DrugRepository : IDrugRepository
	{
        private readonly PharmacyContext _context;

		public DrugRepository(PharmacyContext context)
		{
            _context = context;
		}


        public async Task Add(Drug drug)
        {
            _context.Drugs.Add(drug);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(Drug drug)
        {
            _context.Drugs.Remove(drug);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Drug>> GetAll()=>
            await _context.Drugs.ToListAsync();


        public async Task<Drug> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Drugs.FirstOrDefaultAsync(x=>x.Id == id, token);
            return obj!;
        }


        public async Task<Drug> GetbyName(string name)
        {
            var obj = await _context.Drugs.FirstOrDefaultAsync(x=>x.Name == name);
            return obj!;
        }


        public async Task<IEnumerable<DrugInOrder>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId)
        {
            var drugs = await _context.Drugs.ToListAsync();
            var drugInOrders = (from drug in drugs
                                join ordDrug in ordDrugs on drug.Id equals ordDrug.DrugId
                                select new DrugInOrder
                                {
                                    Name = drug.Name,
                                    Price = ordDrug.Price,
                                    Date = DateTime.UtcNow,
                                    Count = ordDrug.Count
                                })
                                .GroupBy(d => d.Name)
                                .Select(g => new DrugInOrder
                                {
                                    Name = g.Key,
                                    Price = g.First().Price,
                                    Date = DateTime.UtcNow,
                                    Count = g.Sum(d => d.Count)
                                });

            return drugInOrders;
        }


        public async Task<IEnumerable<DrugResult>> GetDrugs(IEnumerable<Availability> availabilities, IEnumerable<Class> classes, IEnumerable<Delivery> deliveries)
        {
            var drugs = await _context.Drugs.ToListAsync();
            var result = from drug in drugs
                         join availability in availabilities on drug.Id equals availability.DrugId
                         join obj in classes on drug.ClassId equals obj.ClassId
                         join delivery in deliveries on availability.DeliveryId equals delivery.Id
                         select new DrugResult
                         {
                             Id = drug.Id,
                             Name = drug.Name,
                             IsRecipe = drug.IsRecipe,
                             Cost = drug.Cost,
                             Count = availability.Count,
                             Type = obj.Type,
                             ExpirationDate = delivery.ExpirationDate
                         };
            return result;
        }


        public async Task Update(Drug drug)
        {
            if (drug != null)
                _context.Drugs.Update(drug);
            await _context.SaveChangesAsync();
        }
    }
}

