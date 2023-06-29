using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IDeliveryService
{
    Task<IBaseResponse<IEnumerable<Delivery>>> GetAll();
    Task<IBaseResponse<Delivery>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Delivery>> Delete(int id);
    Task<IBaseResponse<Delivery>> Delete(Delivery delivery);
    Task<IBaseResponse<Delivery>> Add(Delivery delivery);
    Task<IBaseResponse<Delivery>> Update(Delivery obj);
    Task<IBaseResponse<IEnumerable<Delivery>>> GetFresh();
}

