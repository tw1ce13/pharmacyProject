using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class OrdDrugService : IOrdDrugService
{
    private readonly IBaseRepository<OrdDrug> _ordDrugRepository;
    public OrdDrugService(IBaseRepository<OrdDrug> ordDrugRepository)
    {
        _ordDrugRepository = ordDrugRepository;
    }


    public async Task<IBaseResponse<OrdDrug>> Add(OrdDrug ordDrug)
    {
        await _ordDrugRepository.Add(ordDrug);
        var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
        return baseResponse;
    }


    public async Task<IBaseResponse<OrdDrug>> Delete(int id)
    {
        var ordDrug = new OrdDrug() { Id = id };
        await _ordDrugRepository.Delete(ordDrug);
        var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
        return baseResponse;
    }


    public IBaseResponse<OrdDrug> DeleteRange(IEnumerable<OrdDrug> ordDrugs)
    {
        var ordDrug = new OrdDrug();
        var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
        return baseResponse;
    }


    public async Task<IBaseResponse<OrdDrug>> Delete(OrdDrug ordDrug)
    {
        await _ordDrugRepository.Delete(ordDrug);
        var baseResponse = new BaseResponse<OrdDrug>("Success", StatusCode.OK, ordDrug);
        return baseResponse;
    }


    public async Task<IBaseResponse<OrdDrug>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<OrdDrug>();
        var ordDrug = await _ordDrugRepository.GetById(id, token);
        if (ordDrug == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = ordDrug;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<OrdDrug>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<OrdDrug>>();
        var ordDrug = await _ordDrugRepository.GetAll();
        if (ordDrug == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = ordDrug;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<OrdDrug>> Update(OrdDrug obj)
    {
        var baseResponse = new BaseResponse<OrdDrug>();
        if (obj == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _ordDrugRepository.Update(obj);

        baseResponse.Data = obj;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

