using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IClassService
{
    Task<IBaseResponse<IEnumerable<DrugClass>>> GetAll();
    Task<IBaseResponse<DrugClass>> Get(int id, CancellationToken token);
    Task<IBaseResponse<DrugClass>> Delete(int id);
    Task<IBaseResponse<DrugClass>> Delete(DrugClass obj);
    Task<IBaseResponse<DrugClass>> Add(DrugClass obj);
    Task<IBaseResponse<DrugClass>> Update(DrugClass obj);
}

