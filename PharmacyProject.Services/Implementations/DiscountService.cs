using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly IBaseRepository<Discount> _discountRepository;



        public DiscountService(IBaseRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }



        public IBaseResponse<Discount> Add(Discount discount)
        {
            _discountRepository.Add(discount);
            var baseResponse = new BaseResponse<Discount>("Success", StatusCode.OK, discount);
            return baseResponse;
        }



        public IBaseResponse<Discount> Delete(int id)
        {
            Discount discount = new Discount() { Id = id };
            _discountRepository.Delete(discount);
            var baseResponse = new BaseResponse<Discount>("Success", StatusCode.OK, discount);
            return baseResponse;
        }

        public IBaseResponse<Discount> Delete(Discount discount)
        {
            _discountRepository.Delete(discount);
            var baseResponse = new BaseResponse<Discount>("Success", StatusCode.OK, discount);
            return baseResponse;
        }

        public async Task<IBaseResponse<Discount>> Get(int id)
        {
            var baseResponse = new BaseResponse<Discount>();
            try
            {
                var discount = await _discountRepository.GetById(id);
                if (discount == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = discount;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Discount>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Discount>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Discount>>();
            try
            {
                var discount = await _discountRepository.GetAll();
                if (discount == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = discount;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Discount>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Discount> Update(Discount obj)
        {
            var baseResponse = new BaseResponse<Discount>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                _discountRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Discount>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

