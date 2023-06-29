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



    public async Task<IBaseResponse<DrugClass>> Add(DrugClass @class)
    {
        await _classRepository.Add(@class);
        var baseResponse = new BaseResponse<DrugClass>("Success", StatusCode.OK, @class);

        return baseResponse;
    }



    public async Task<IBaseResponse<DrugClass>> Delete(int id)
    {
        var obj = new DrugClass()
        {
            Id = id
        };
        await _classRepository.Delete(obj);
        var baseResponse = new BaseResponse<DrugClass>("Success", StatusCode.OK, obj);

        return baseResponse;
    }

    public async Task<IBaseResponse<DrugClass>> Delete(DrugClass @class)
    {
        await _classRepository.Delete(@class);
        var baseResponse = new BaseResponse<DrugClass>("Success", StatusCode.OK, @class);

        return baseResponse;
    }

    public async Task<IBaseResponse<DrugClass>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<DrugClass>();
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


    public async Task<IBaseResponse<IEnumerable<DrugClass>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<DrugClass>>();
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

    public async Task<IBaseResponse<DrugClass>> Update(DrugClass @class)
    {
        var baseResponse = new BaseResponse<DrugClass>();
        if (@class == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }



        await _classRepository.Update(@class);

        baseResponse.Data = @class;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

