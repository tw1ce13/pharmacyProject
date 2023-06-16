using System;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;

namespace PharmacyProject.Services.Interfaces
{
	public interface IDiscountService
	{
        Task<IBaseResponse<IEnumerable<Discount>>> GetAll();
        Task<IBaseResponse<Discount>> Get(int id);
        IBaseResponse<Discount> Delete(int id);
        IBaseResponse<Discount> Delete(Discount obj);
        IBaseResponse<Discount> Add(Discount obj);
        IBaseResponse<Discount> Update(Discount obj);
    }
}

