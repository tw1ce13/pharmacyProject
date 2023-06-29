using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IPharmacyService
{
    Task<IBaseResponse<IEnumerable<Pharmacy>>> GetAll();
    Task<IBaseResponse<Pharmacy>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Pharmacy>> Delete(int id);
    Task<IBaseResponse<Pharmacy>> Delete(Pharmacy obj);
    Task<IBaseResponse<Pharmacy>> Add(Pharmacy obj);
    Task<IBaseResponse<Pharmacy>> Update(Pharmacy obj);
}

