using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IDeliveryService
	{
        Task<IBaseResponse<IEnumerable<Delivery>>> GetAll();
        Task<IBaseResponse<Delivery>> Get(int id);
        IBaseResponse<Delivery> Delete(int id);
        IBaseResponse<Delivery> Delete(Delivery delivery);
        IBaseResponse<Delivery> Add(Delivery delivery);
        IBaseResponse<Delivery> Update(Delivery obj);
        Task<IBaseResponse<IEnumerable<Delivery>>> GetFresh();
    }
}

