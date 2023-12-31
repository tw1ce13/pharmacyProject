﻿using PharmacyProject.Domain.Models;

namespace PharmacyProject.DAL.Interfaces;

public interface IAvailabilityRepository : IBaseRepository<Availability>
{
	Task<IEnumerable<Availability>> GetAvailabilitiesByPharmacyId(int pharmacyId);
	Task<IEnumerable<Availability>> GetAvailabilitiesByDelivery(IEnumerable<int> deliveriesId);
}

