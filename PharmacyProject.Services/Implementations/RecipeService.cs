using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IBaseRepository<Recipe> _recipeRepository;



        public RecipeService(IBaseRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }



        public async Task<IBaseResponse<Recipe>> Add(Recipe recipe)
        {
            await _recipeRepository.Add(recipe);
            var baseResponse = new BaseResponse<Recipe>("Success", StatusCode.OK, recipe);

            return baseResponse;
        }



        public async Task<IBaseResponse<Recipe>> Delete(int id)
        {
            Recipe recipe = new Recipe() { Id = id };
            await _recipeRepository.Delete(recipe);
            var baseResponse = new BaseResponse<Recipe>("Success", StatusCode.OK, recipe);

            return baseResponse;
        }

        public async Task<IBaseResponse<Recipe>> Delete(Recipe recipe)
        {
            await _recipeRepository.Delete(recipe);
            var baseResponse = new BaseResponse<Recipe>("Success", StatusCode.OK, recipe);

            return baseResponse;
        }

        public async Task<IBaseResponse<Recipe>> Get(int id, CancellationToken token)
        {
            var baseResponse = new BaseResponse<Recipe>();
            var recipe = await _recipeRepository.GetById(id, token);
            if (recipe == null)
            {
                baseResponse.Description = "Не найдено";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            baseResponse.Data = recipe;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        public async Task<IBaseResponse<IEnumerable<Recipe>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Recipe>>();
            var recipe = await _recipeRepository.GetAll();
            if (recipe == null)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            baseResponse.Data = recipe;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }

        public async Task<IBaseResponse<Recipe>> Update(Recipe obj)
        {
            var baseResponse = new BaseResponse<Recipe>();
            if (obj == null)
            {
                baseResponse.Description = "Объект не найден";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }


            await _recipeRepository.Update(obj);

            baseResponse.Data = obj;
            baseResponse.Description = "успешно";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
    }
}

