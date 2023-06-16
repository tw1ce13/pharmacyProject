using System;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Interfaces
{
	public interface IDrugRepository : IBaseRepository<Drug>
	{
		Task<IEnumerable<DrugResult>> GetDrugs(IEnumerable<Availability> availabilities, IEnumerable<Class> classes, IEnumerable<Delivery> deliveries);
		Task<IEnumerable<DrugInOrder>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId);
	}
}

