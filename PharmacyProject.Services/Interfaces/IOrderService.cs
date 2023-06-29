using PharmacyProject.Services.Response;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.Services.Interfaces;

public interface IOrderService
{
    Task<IBaseResponse<IEnumerable<Order>>> GetAll();
    Task<IBaseResponse<Order>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Order>> Delete(int id);
    Task<IBaseResponse<Order>> Delete(Order obj);
    IBaseResponse<Order> DeleteRange(IEnumerable<Order> orders);
    Task<IBaseResponse<Order>> Add(Order obj);
    Task<IBaseResponse<Order>> Update(Order obj);
}

