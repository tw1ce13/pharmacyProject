using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IBaseRepository<Pharmacy> _pharmacyRepository;



        public PharmacyService(IBaseRepository<Pharmacy> pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }



        public IBaseResponse<Pharmacy> Add(Pharmacy pharmacy)
        {
            _pharmacyRepository.Add(pharmacy);
            var baseResponse = new BaseResponse<Pharmacy>("Success", StatusCode.OK, pharmacy);
            return baseResponse;
        }



        public IBaseResponse<Pharmacy> Delete(int id)
        {
            Pharmacy pharmacy = new Pharmacy() { Id = id };
            _pharmacyRepository.Delete(pharmacy);
            var baseResponse = new BaseResponse<Pharmacy>("Success", StatusCode.OK, pharmacy);
            return baseResponse;
        }

        public IBaseResponse<Pharmacy> Delete(Pharmacy pharmacy)
        {
            _pharmacyRepository.Delete(pharmacy);
            var baseResponse = new BaseResponse<Pharmacy>("Success", StatusCode.OK, pharmacy);
            return baseResponse;
        }

        public async Task<IBaseResponse<Pharmacy>> Get(int id)
        {
            var baseResponse = new BaseResponse<Pharmacy>();
            try
            {
                var pharmacy = await _pharmacyRepository.GetById(id);
                if (pharmacy == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = pharmacy;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Pharmacy>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Pharmacy>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Pharmacy>>();
            try
            {
                var pharmacy = await _pharmacyRepository.GetAll();
                if (pharmacy == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = pharmacy;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Pharmacy>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Pharmacy> Update(Pharmacy obj)
        {
            var baseResponse = new BaseResponse<Pharmacy>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                _pharmacyRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Pharmacy>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

