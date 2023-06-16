using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
    public interface IClassService
    {
        Task<IBaseResponse<IEnumerable<Class>>> GetAll();
        Task<IBaseResponse<Class>> Get(int id);
        IBaseResponse<Class> Delete(int id);
        IBaseResponse<Class> Delete(Class obj);
        IBaseResponse<Class> Add(Class obj);
        IBaseResponse<Class> Update(Class obj);
    }
}

