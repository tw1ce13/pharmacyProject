using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IRecipeDrugService
	{
        Task<IBaseResponse<IEnumerable<RecipeDrug>>> GetAll();
        Task<IBaseResponse<RecipeDrug>> Get(int id);
        IBaseResponse<RecipeDrug> Delete(int id);
        IBaseResponse<RecipeDrug> Delete(RecipeDrug obj);
        IBaseResponse<RecipeDrug> Add(RecipeDrug obj);
        IBaseResponse<RecipeDrug> Update(RecipeDrug obj);
    }
}

