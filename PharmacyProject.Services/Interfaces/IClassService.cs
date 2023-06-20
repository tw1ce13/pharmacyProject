using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
    public interface IClassService
    {
        Task<IBaseResponse<IEnumerable<Class>>> GetAll();
        Task<IBaseResponse<Class>> Get(int id, CancellationToken token);
        Task<IBaseResponse<Class>> Delete(int id);
        Task<IBaseResponse<Class>> Delete(Class obj);
        Task<IBaseResponse<Class>> Add(Class obj);
        Task<IBaseResponse<Class>> Update(Class obj);
    }
}

