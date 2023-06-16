using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IRecipeService
	{
        Task<IBaseResponse<IEnumerable<Recipe>>> GetAll();
        Task<IBaseResponse<Recipe>> Get(int id);
        IBaseResponse<Recipe> Delete(int id);
        IBaseResponse<Recipe> Delete(Recipe obj);
        IBaseResponse<Recipe> Add(Recipe obj);
        IBaseResponse<Recipe> Update(Recipe obj);
    }
}

