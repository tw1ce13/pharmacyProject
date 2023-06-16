using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class RecipeDrugService : IRecipeDrugService
    {
        private readonly IBaseRepository<RecipeDrug> _recipeDrugRepository;



        public RecipeDrugService(IBaseRepository<RecipeDrug> recipeDrugRepository)
        {
            _recipeDrugRepository = recipeDrugRepository;
        }



        public IBaseResponse<RecipeDrug> Add(RecipeDrug recipeDrug)
        {
            _recipeDrugRepository.Add(recipeDrug);
            var baseResponse = new BaseResponse<RecipeDrug>("Success", StatusCode.OK, recipeDrug);
            return baseResponse;
        }


        public IBaseResponse<RecipeDrug> Delete(int id)
        {
            RecipeDrug recipeDrug = new RecipeDrug() { Id = id };
            _recipeDrugRepository.Delete(recipeDrug);
            var baseResponse = new BaseResponse<RecipeDrug>("Success", StatusCode.OK, recipeDrug);

            return baseResponse;
        }

        public IBaseResponse<RecipeDrug> Delete(RecipeDrug recipeDrug)
        {
            _recipeDrugRepository.Delete(recipeDrug);
            var baseResponse = new BaseResponse<RecipeDrug>("Success", StatusCode.OK, recipeDrug);

            return baseResponse;
        }

        public async Task<IBaseResponse<RecipeDrug>> Get(int id)
        {
            var baseResponse = new BaseResponse<RecipeDrug>();
            try
            {
                var recipeDrug = await _recipeDrugRepository.GetById(id);
                if (recipeDrug == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = recipeDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<RecipeDrug>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<RecipeDrug>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<RecipeDrug>>();
            try
            {
                var recipeDrug = await _recipeDrugRepository.GetAll();
                if (recipeDrug == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = recipeDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<RecipeDrug>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<RecipeDrug> Update(RecipeDrug obj)
        {
            var baseResponse = new BaseResponse<RecipeDrug>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                _recipeDrugRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<RecipeDrug>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}


