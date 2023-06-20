using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IWebService
	{
        Task<IBaseResponse<IEnumerable<Web>>> GetAll();
        Task<IBaseResponse<Web>> Get(int id, CancellationToken token);
        Task<IBaseResponse<Web>> Delete(int id);
        Task<IBaseResponse<Web>> Delete(Web web);
        Task<IBaseResponse<Web>> Add(Web web);
        Task<IBaseResponse<Web>> Update(Web obj);
    }
}

