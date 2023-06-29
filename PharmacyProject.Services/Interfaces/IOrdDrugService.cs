using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IOrdDrugService
{
    Task<IBaseResponse<IEnumerable<OrdDrug>>> GetAll();
    Task<IBaseResponse<OrdDrug>> Get(int id, CancellationToken token);
    Task<IBaseResponse<OrdDrug>> Delete(int id, CancellationToken token);
    Task<IBaseResponse<OrdDrug>> Delete(OrdDrug obj);
    IBaseResponse<OrdDrug> DeleteRange(IEnumerable<OrdDrug> ordDrugs);
    Task<IBaseResponse<OrdDrug>> Add(OrdDrug obj);
    Task<IBaseResponse<OrdDrug>> Update(OrdDrug obj);
}

