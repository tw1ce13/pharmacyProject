using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class OrdDrugService : IOrdDrugService
    {
        private readonly IBaseRepository<OrdDrug> _ordDrugRepository;



        public OrdDrugService(IBaseRepository<OrdDrug> ordDrugRepository)
        {
            _ordDrugRepository = ordDrugRepository;
        }



        public IBaseResponse<OrdDrug> Add(OrdDrug ordDrug)
        {
            _ordDrugRepository.Add(ordDrug);
            var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
            return baseResponse;
        }

        public IBaseResponse<OrdDrug> Delete(int id)
        {
            OrdDrug ordDrug = new OrdDrug() { Id = id };
            _ordDrugRepository.Delete(ordDrug);
            var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
            return baseResponse;
        }

        public IBaseResponse<OrdDrug> DeleteRange(IEnumerable<OrdDrug> ordDrugs)
        {
            OrdDrug ordDrug = new OrdDrug();
            var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
            return baseResponse;
        }

        public IBaseResponse<OrdDrug> Delete(OrdDrug ordDrug)
        {
            _ordDrugRepository.Delete(ordDrug);
            var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
            return baseResponse;
        }

        public async Task<IBaseResponse<OrdDrug>> Get(int id)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            try
            {
                var ordDrug = await _ordDrugRepository.GetById(id);
                if (ordDrug == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ordDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdDrug>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<OrdDrug>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<OrdDrug>>();
            try
            {
                var ordDrug = await _ordDrugRepository.GetAll();
                if (ordDrug == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ordDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrdDrug>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<OrdDrug> Update(OrdDrug obj)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                _ordDrugRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdDrug>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

