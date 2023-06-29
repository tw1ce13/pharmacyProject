using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IAvailabilityService
{
    Task<IBaseResponse<IEnumerable<Availability>>> GetAll();
    Task<IBaseResponse<Availability>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Availability>> Delete(int id, CancellationToken token);
    Task<IBaseResponse<Availability>> Delete(Availability obj);
    Task<IBaseResponse<Availability>> Add(Availability obj);
    Task<IBaseResponse<Availability>> Update(Availability obj);
    Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilitiesByPharmacyId(int pharmacyId);
    Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilitiesByDelivery(IEnumerable<int> deliveriesId);
}

