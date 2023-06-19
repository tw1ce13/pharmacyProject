using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IAvailabilityService
	{
        Task<IBaseResponse<IEnumerable<Availability>>> GetAll();
        Task<IBaseResponse<Availability>> Get(int id, CancellationToken token);
        IBaseResponse<Availability> Delete(int id);
        IBaseResponse<Availability> Delete(Availability obj);
        IBaseResponse<Availability> Add(Availability obj);
        IBaseResponse<Availability> Update(Availability obj);
        Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilitiesByPharmacyId(int pharmacyId);
        Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilityByDelivery(IEnumerable<int> deliveriesId);
    }
}

