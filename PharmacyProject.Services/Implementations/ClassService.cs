using System.Security.Claims;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class ClassService : IClassService
{
    private readonly IBaseRepository<DrugClass> _classRepository;
    public ClassService(IBaseRepository<DrugClass> classRepository)
    {
        _classRepository = classRepository;
    }


    public async Task<IBaseResponse<DrugClass>> Add(DrugClass drugClass)
    {
        await _classRepository.Add(drugClass);
        var baseResponse = new BaseResponse<DrugClass>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = drugClass
        };

        return baseResponse;
    }


    public async Task<IBaseResponse<DrugClass>> Delete(int id, CancellationToken token)
    {
        var drugClasses = await _classRepository.GetById(id, token);
        await _classRepository.Delete(drugClasses);
        var baseResponse = new BaseResponse<DrugClass>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = drugClasses
        };

        return baseResponse;
    }


    public async Task<IBaseResponse<DrugClass>> Delete(DrugClass drugClass)
    {
        await _classRepository.Delete(drugClass);
        var baseResponse = new BaseResponse<DrugClass>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = drugClass
        };

        return baseResponse;
    }


    public async Task<IBaseResponse<DrugClass>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<DrugClass>();
        var drugClass = await _classRepository.GetById(id, token);
        if (drugClass == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = drugClass;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<DrugClass>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<DrugClass>>();
        var drugClasses = await _classRepository.GetAll();
        if (drugClasses == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = drugClasses;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<DrugClass>> Update(DrugClass drugClass)
    {
        var baseResponse = new BaseResponse<DrugClass>();
        if (drugClass == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }



        await _classRepository.Update(drugClass);

        baseResponse.Data = drugClass;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

