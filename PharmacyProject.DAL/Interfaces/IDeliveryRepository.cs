using System;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Interfaces
{
	public interface IDeliveryRepository : IBaseRepository<Delivery>
	{
		Task<IEnumerable<Delivery>> GetFresh();
	}
}

