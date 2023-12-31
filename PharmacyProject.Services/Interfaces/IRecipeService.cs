﻿using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Interfaces;

public interface IRecipeService
{
    Task<IBaseResponse<IEnumerable<Recipe>>> GetAll();
    Task<IBaseResponse<Recipe>> Get(int id, CancellationToken token);
    Task<IBaseResponse<Recipe>> Delete(int id, CancellationToken token);
    Task<IBaseResponse<Recipe>> Delete(Recipe obj);
    Task<IBaseResponse<Recipe>> Add(Recipe obj);
    Task<IBaseResponse<Recipe>> Update(Recipe obj);
}

