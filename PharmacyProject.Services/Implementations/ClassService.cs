using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IBaseRepository<Class> _classRepository;



        public ClassService(IBaseRepository<Class> classRepository)
        {
            _classRepository = classRepository;
        }



        public IBaseResponse<Class> Add(Class obj)
        {
            _classRepository.Add(obj);
            var baseResponse = new BaseResponse<Class>("Success", StatusCode.OK, obj);

            return baseResponse;
        }



        public IBaseResponse<Class> Delete(int id)
        {
            Class obj = new Class()
            {
                ClassId = id
            };
            _classRepository.Delete(obj);
            var baseResponse = new BaseResponse<Class>("Success", StatusCode.OK, obj);

            return baseResponse;
        }

        public IBaseResponse<Class> Delete(Class obj)
        {
            _classRepository.Delete(obj);
            var baseResponse = new BaseResponse<Class>("Success", StatusCode.OK, obj);

            return baseResponse;
        }

        public async Task<IBaseResponse<Class>> Get(int id)
        {
            var baseResponse = new BaseResponse<Class>();
            try
            {
                var obj = await _classRepository.GetById(id);
                if (obj == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = obj;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Class>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Class>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Class>>();
            try
            {
                var obj = await _classRepository.GetAll();
                if (obj == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = obj;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Class>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public  IBaseResponse<Class> Update(Class obj)
        {
            var baseResponse = new BaseResponse<Class>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }



                _classRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Class>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

