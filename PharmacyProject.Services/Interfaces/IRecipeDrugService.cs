using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IRecipeDrugService
{
    Task<IBaseResponse<IEnumerable<RecipeDrug>>> GetAll();
    Task<IBaseResponse<RecipeDrug>> Get(int id, CancellationToken token);
    Task<IBaseResponse<RecipeDrug>> Delete(int id);
    Task<IBaseResponse<RecipeDrug>> Delete(RecipeDrug obj);
    Task<IBaseResponse<RecipeDrug>> Add(RecipeDrug obj);
    Task<IBaseResponse<RecipeDrug>> Update(RecipeDrug obj);
}

