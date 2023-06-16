using System;
using PharmacyProject.Domain.Response;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.Services.Interfaces
{
	public interface IOrderService
	{
        Task<IBaseResponse<IEnumerable<Order>>> GetAll();
        Task<IBaseResponse<Order>> Get(int id);
        IBaseResponse<Order> Delete(int id);
        IBaseResponse<Order> Delete(Order obj);
        IBaseResponse<Order> DeleteRange(IEnumerable<Order> orders);
        IBaseResponse<Order> Add(Order obj);
        IBaseResponse<Order> Update(Order obj);
    }
}

