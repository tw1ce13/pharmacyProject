using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IPatientService
	{
        Task<IBaseResponse<IEnumerable<Patient>>> GetAll();
        Task<IBaseResponse<Patient>> Get(int id);
        IBaseResponse<Patient> Delete(int id);
        IBaseResponse<Patient> Delete(Patient obj);
        IBaseResponse<Patient> Add(Patient obj);
        IBaseResponse<Patient> Update(Patient obj);
    }
}

