using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class WebService : IWebService
{
    private readonly IBaseRepository<Web> _webRepository;
    public WebService(IBaseRepository<Web> webRepository)
    {
        _webRepository = webRepository;
    }


    public async Task<IBaseResponse<Web>> Add(Web web)
    {
        await _webRepository.Add(web);
        var baseResponse = new BaseResponse<Web>("Success", StatusCode.OK, web);

        return baseResponse;
    }


    public async Task<IBaseResponse<Web>> Delete(int id)
    {
        var web = new Web() { Id = id };
        await _webRepository.Delete(web);
        var baseResponse = new BaseResponse<Web>("Success", StatusCode.OK, web);

        return baseResponse;
    }


    public async Task<IBaseResponse<Web>> Delete(Web web)
    {
        await _webRepository.Delete(web);
        var baseResponse = new BaseResponse<Web>("Success", StatusCode.OK, web);

        return baseResponse;
    }


    public async Task<IBaseResponse<Web>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Web>();
        var web = await _webRepository.GetById(id, token);
        if (web == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = web;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;

    }


    public async Task<IBaseResponse<IEnumerable<Web>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Web>>();
        var webs = await _webRepository.GetAll();
        if (webs == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = webs;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;

    }

    public async Task<IBaseResponse<Web>> Update(Web obj)
    {
        var baseResponse = new BaseResponse<Web>();
        if (obj == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _webRepository.Update(obj);

        baseResponse.Data = obj;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

