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
        var baseResponse = new BaseResponse<RecipeDrug>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = recipeDrug
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<RecipeDrug>> Delete(int id, CancellationToken token)
    {
        var recipeDrug = await _recipeDrugRepository.GetById(id, token);
        await _recipeDrugRepository.Delete(recipeDrug);
        var baseResponse = new BaseResponse<RecipeDrug>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = recipeDrug
        };

        return baseResponse;
    }


    public async Task<IBaseResponse<RecipeDrug>> Delete(RecipeDrug recipeDrug)
    {
        await _recipeDrugRepository.Delete(recipeDrug);
        var baseResponse = new BaseResponse<RecipeDrug>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = recipeDrug
        };

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
        var recipeDrugs = await _recipeDrugRepository.GetAll();
        if (recipeDrugs == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = recipeDrugs;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<RecipeDrug>> Update(RecipeDrug recipeDrug)
    {
        var baseResponse = new BaseResponse<RecipeDrug>();
        if (recipeDrug == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _recipeDrugRepository.Update(recipeDrug);

        baseResponse.Data = recipeDrug;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}


