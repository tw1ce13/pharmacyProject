using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class RecipeDrugService : IRecipeDrugService
{
    private readonly IBaseRepository<RecipeDrug> _recipeDrugRepository;
    public RecipeDrugService(IBaseRepository<RecipeDrug> recipeDrugRepository)
    {
        _recipeDrugRepository = recipeDrugRepository;
    }


    public async Task<IBaseResponse<RecipeDrug>> Add(RecipeDrug recipeDrug)
    {
        await _recipeDrugRepository.Add(recipeDrug);
        var baseResponse = new BaseResponse<RecipeDrug>("Success", StatusCode.OK, recipeDrug);
        return baseResponse;
    }


    public async Task<IBaseResponse<RecipeDrug>> Delete(int id)
    {
        var recipeDrug = new RecipeDrug() { Id = id };
        await _recipeDrugRepository.Delete(recipeDrug);
        var baseResponse = new BaseResponse<RecipeDrug>("Success", StatusCode.OK, recipeDrug);

        return baseResponse;
    }


    public async Task<IBaseResponse<RecipeDrug>> Delete(RecipeDrug recipeDrug)
    {
        await _recipeDrugRepository.Delete(recipeDrug);
        var baseResponse = new BaseResponse<RecipeDrug>("Success", StatusCode.OK, recipeDrug);

        return baseResponse;
    }


    public async Task<IBaseResponse<RecipeDrug>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<RecipeDrug>();
        var recipeDrug = await _recipeDrugRepository.GetById(id, token);
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


    public async Task<IBaseResponse<IEnumerable<RecipeDrug>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<RecipeDrug>>();
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


    public async Task<IBaseResponse<RecipeDrug>> Update(RecipeDrug obj)
    {
        var baseResponse = new BaseResponse<RecipeDrug>();
        if (obj == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _recipeDrugRepository.Update(obj);

        baseResponse.Data = obj;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}


