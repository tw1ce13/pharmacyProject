using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IWebService
	{
        Task<IBaseResponse<IEnumerable<Web>>> GetAll();
        Task<IBaseResponse<Web>> Get(int id);
        IBaseResponse<Web> Delete(int id);
        IBaseResponse<Web> Delete(Web web);
        IBaseResponse<Web> Add(Web web);
        IBaseResponse<Web> Update(Web obj);
    }
}

