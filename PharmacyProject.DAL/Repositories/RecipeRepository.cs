﻿using System;
using Microsoft.EntityFrameworkCore;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
namespace PharmacyProject.DAL.Repositories
{
	public class RecipeRepository : IBaseRepository<Recipe>
	{
		private readonly PharmacyContext _context;
		public RecipeRepository(PharmacyContext context)
		{
			_context = context;
		}

        public void Add(Recipe data)
        {
            _context.Recipes.Add(data);
            _context.SaveChangesAsync();
        }

        public void Delete(Recipe data)
        {
            _context.Recipes.Remove(data);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Recipe>> GetAll()
        {
            var list = await _context.Recipes.ToListAsync();
            return list;
        }

        public async Task<Recipe> GetById(int id, CancellationToken token)
        {
            var obj = await _context.Recipes.FirstOrDefaultAsync(x => x.Id == id, token);
            return obj!;
        }

        public async Task<Recipe> GetbyName(string name)
        {
            var obj = await _context.Recipes.FindAsync(name);
            return obj!;
        }

        public async Task Update(Recipe data)
        {
            if (data != null)
                _context.Recipes.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}

