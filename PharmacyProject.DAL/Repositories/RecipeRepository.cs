using System;
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

        public void Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChangesAsync();
        }

        public void Delete(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Recipe>> GetAll()=>
            await _context.Recipes.ToListAsync();

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

        public async Task Update(Recipe recipe)
        {
            if (recipe != null)
                _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}

