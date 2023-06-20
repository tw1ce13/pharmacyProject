using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IDrugService
	{
        Task<IBaseResponse<IEnumerable<Drug>>> GetAll(CancellationToken cancellationToken);
        Task<IBaseResponse<Drug>> Get(int id, CancellationToken token);
        Task<IBaseResponse<Drug>> Delete(int id);
        Task<IBaseResponse<Drug>> Delete(Drug obj);
        Task<IBaseResponse<Drug>> Add(Drug obj);
        Task<IBaseResponse<Drug>> Update(Drug obj);
        Task<BaseResponse<IEnumerable<DrugResult>>> GetDrugs(IEnumerable<Availability> availabilities, IEnumerable<Class> classes, IEnumerable<Delivery> deliveries);
        Task<BaseResponse<IEnumerable<DrugInOrder>>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId);
    }
}

