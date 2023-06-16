using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IDrugService
	{
        Task<IBaseResponse<IEnumerable<Drug>>> GetAll(CancellationToken cancellationToken);
        Task<IBaseResponse<Drug>> Get(int id);
        IBaseResponse<Drug> Delete(int id);
        IBaseResponse<Drug> Delete(Drug obj);
        IBaseResponse<Drug> Add(Drug obj);
        IBaseResponse<Drug> Update(Drug obj);
        Task<BaseResponse<IEnumerable<DrugResult>>> GetDrugs(IEnumerable<Availability> availabilities, IEnumerable<Class> classes, IEnumerable<Delivery> deliveries);
        Task<BaseResponse<IEnumerable<DrugInOrder>>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId);
    }
}

