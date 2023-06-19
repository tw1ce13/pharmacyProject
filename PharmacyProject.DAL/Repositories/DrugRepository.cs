﻿using System;
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

        public void Add(Drug drug)
        {
            _context.Drugs.Add(drug);
            _context.SaveChangesAsync();
        }

        public void Delete(Drug drug)
        {
            _context.Drugs.Remove(drug);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Drug>> GetAll()=>
            await _context.Drugs.ToListAsync();

        public async Task<Drug> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Drugs.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Drug> GetbyName(string name)
        {
            var obj = await _context.Drugs.FindAsync(name);
            return obj!;
        }

        public async Task<IEnumerable<DrugInOrder>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId)
        {
            var drugs = await _context.Drugs.ToListAsync();
            var result = (from drug in drugs
                          join order in orders on userId equals order.PatientId
                          join ordDrug in ordDrugs on drug.Id equals ordDrug.DrugId
                          select new DrugInOrder
                          {
                              Name = drug.Name,
                              Price = ordDrug.Price,
                              Date = order.Date,
                              Count = ordDrug.Count
                          }).Distinct();
            return result;
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
                             ExpirationData = delivery.ExpirationData
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

