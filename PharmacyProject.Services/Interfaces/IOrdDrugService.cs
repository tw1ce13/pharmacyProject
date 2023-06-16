using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IOrdDrugService
	{
        Task<IBaseResponse<IEnumerable<OrdDrug>>> GetAll();
        Task<IBaseResponse<OrdDrug>> Get(int id);
        IBaseResponse<OrdDrug> Delete(int id);
        IBaseResponse<OrdDrug> Delete(OrdDrug obj);
        IBaseResponse<OrdDrug> DeleteRange(IEnumerable<OrdDrug> ordDrugs);
        IBaseResponse<OrdDrug> Add(OrdDrug obj);
        IBaseResponse<OrdDrug> Update(OrdDrug obj);
    }
}

