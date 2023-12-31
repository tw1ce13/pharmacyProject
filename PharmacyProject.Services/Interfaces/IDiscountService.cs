﻿using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IDiscountService
{
    Task<IBaseResponse<IEnumerable<Discount>>> GetAll();
    Task<IBaseResponse<Discount>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Discount>> Delete(int id, CancellationToken token);
    Task<IBaseResponse<Discount>> Delete(Discount obj);
    Task<IBaseResponse<Discount>> Add(Discount obj);
    Task<IBaseResponse<Discount>> Update(Discount obj);
}

