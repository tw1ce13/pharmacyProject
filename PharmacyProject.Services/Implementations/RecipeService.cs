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



        public IBaseResponse<Recipe> Add(Recipe recipe)
        {
            _recipeRepository.Add(recipe);
            var baseResponse = new BaseResponse<Recipe>("Success", StatusCode.OK, recipe);

            return baseResponse;
        }



        public IBaseResponse<Recipe> Delete(int id)
        {
            Recipe recipe = new Recipe() { Id = id };
            _recipeRepository.Delete(recipe);
            var baseResponse = new BaseResponse<Recipe>("Success", StatusCode.OK, recipe);

            return baseResponse;
        }

        public IBaseResponse<Recipe> Delete(Recipe recipe)
        {
            _recipeRepository.Delete(recipe);
            var baseResponse = new BaseResponse<Recipe>("Success", StatusCode.OK, recipe);

            return baseResponse;
        }

        public async Task<IBaseResponse<Recipe>> Get(int id)
        {
            var baseResponse = new BaseResponse<Recipe>();
            try
            {
                var recipe = await _recipeRepository.GetById(id);
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
            catch (Exception ex)
            {
                return new BaseResponse<Recipe>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Recipe>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Recipe>>();
            try
            {
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
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Recipe>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Recipe> Update(Recipe obj)
        {
            var baseResponse = new BaseResponse<Recipe>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                _recipeRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Recipe>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

