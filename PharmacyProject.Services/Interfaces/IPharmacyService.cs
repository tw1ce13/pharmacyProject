using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IPharmacyService
	{
        Task<IBaseResponse<IEnumerable<Pharmacy>>> GetAll();
        Task<IBaseResponse<Pharmacy>> Get(int id);
        IBaseResponse<Pharmacy> Delete(int id);
        IBaseResponse<Pharmacy> Delete(Pharmacy obj);
        IBaseResponse<Pharmacy> Add(Pharmacy obj);
        IBaseResponse<Pharmacy> Update(Pharmacy obj);
    }
}

