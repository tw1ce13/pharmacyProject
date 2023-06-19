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



        public IBaseResponse<Class> Add(Class @class)
        {
            _classRepository.Add(@class);
            var baseResponse = new BaseResponse<Class>("Success", StatusCode.OK, @class);

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

        public IBaseResponse<Class> Delete(Class @class)
        {
            _classRepository.Delete(@class);
            var baseResponse = new BaseResponse<Class>("Success", StatusCode.OK, @class);

            return baseResponse;
        }

        public async Task<IBaseResponse<Class>> Get(int id, CancellationToken token)
        {
            var baseResponse = new BaseResponse<Class>();
            var obj = await _classRepository.GetById(id, token);
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


        public async Task<IBaseResponse<IEnumerable<Class>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Class>>();
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

        public IBaseResponse<Class> Update(Class @class)
        {
            var baseResponse = new BaseResponse<Class>();
            if (@class == null)
            {
                baseResponse.Description = "Объект не найден";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }



            _classRepository.Update(@class);

            baseResponse.Data = @class;
            baseResponse.Description = "успешно";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
    }
}

