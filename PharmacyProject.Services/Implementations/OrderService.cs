using System;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;
using System.Security.Cryptography;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
using PharmacyProject.DAL.Repositories;

namespace PharmacyProject.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _ordRepository;



        public OrderService(IBaseRepository<Order> ordRepository)
        {
            _ordRepository = ordRepository;
        }



        public IBaseResponse<Order> Add(Order ord)
        {
            _ordRepository.Add(ord);
            var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, ord);
            return baseResponse;
        }



        public IBaseResponse<Order> Delete(int id)
        {
            Order ord = new Order() { Id = id };
            _ordRepository.Delete(ord);
            var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, ord);
            return baseResponse;
        }

        public IBaseResponse<Order> DeleteRange(IEnumerable<Order> orders)
        {
            Order order = new Order();
            var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, order);
            return baseResponse;
        }


        public IBaseResponse<Order> Delete(Order ord)
        {
            _ordRepository.Delete(ord);
            var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, ord);
            return baseResponse;
        }

        public async Task<IBaseResponse<Order>> Get(int id)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var ord = await _ordRepository.GetById(id);
                if (ord == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ord;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Order>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();
            try
            {
                var ord = await _ordRepository.GetAll();
                if (ord == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ord;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }


        public IBaseResponse<Order> Update(Order obj)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                _ordRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

