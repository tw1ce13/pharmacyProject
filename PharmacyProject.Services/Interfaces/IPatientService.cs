using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IPatientService
{
    Task<IBaseResponse<IEnumerable<Patient>>> GetAll();
    Task<IBaseResponse<Patient>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Patient>> Delete(int id);
    Task<IBaseResponse<Patient>> Delete(Patient obj);
    Task<IBaseResponse<Patient>> Add(Patient obj);
    Task<IBaseResponse<Patient>> Update(Patient obj);
}

