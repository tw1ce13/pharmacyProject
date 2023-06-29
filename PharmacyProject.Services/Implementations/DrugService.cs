using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class DrugService : IDrugService
{
    private readonly IDrugRepository _drugRepository;
    public DrugService(IDrugRepository drugRepository)
    {
        _drugRepository = drugRepository;
    }


    public async Task<IBaseResponse<Drug>> Add(Drug drug)
    {
        await _drugRepository.Add(drug);
        var baseResponse = new BaseResponse<Drug>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = drug
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Drug>> Delete(int id, CancellationToken token)
    {
        var drug = await _drugRepository.GetById(id, token);
        await _drugRepository.Delete(drug);
        var baseResponse = new BaseResponse<Drug>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = drug
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Drug>> Delete(Drug drug)
    {
        await _drugRepository.Delete(drug);
        var baseResponse = new BaseResponse<Drug>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = drug
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Drug>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Drug>();
        var drug = await _drugRepository.GetById(id, token);
        if (drug == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = drug;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Drug>>> GetAll(CancellationToken cancellationToken)
    {
        var baseResponse = new BaseResponse<IEnumerable<Drug>>();
        if (cancellationToken.IsCancellationRequested)
        {
            return new BaseResponse<IEnumerable<Drug>>()
            {
                StatusCode = StatusCode.Cancelled,
                Description = "Операция была отменена."
            };
        }

        var drugs = await _drugRepository.GetAll();

        if (cancellationToken.IsCancellationRequested)
        {
            return new BaseResponse<IEnumerable<Drug>>()
            {
                StatusCode = StatusCode.Cancelled,
                Description = "Операция была отменена после выполнения."
            };
        }

        if (drugs == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = drugs;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;

    }


    public async Task<BaseResponse<IEnumerable<DrugInOrder>>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId)
    {
        var baseResponse = new BaseResponse<IEnumerable<DrugInOrder>>();
        var drugs = await _drugRepository.GetDrugInOrders(orders, ordDrugs, userId);

        if (drugs == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = drugs;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<BaseResponse<IEnumerable<DrugResult>>> GetDrugs(IEnumerable<Availability> availabilities, IEnumerable<DrugClass> classes, IEnumerable<Delivery> deliveries)
    {
        var baseResponse = new BaseResponse<IEnumerable<DrugResult>>();
        var drugs = await _drugRepository.GetDrugs(availabilities, classes, deliveries);
        if (drugs == null)
        {
            baseResponse.Description = "Не найдено объектов";
            baseResponse.StatusCode = StatusCode.ObjectNotFound;
            return baseResponse;
        }
        baseResponse.Data = drugs;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;

    }


    public async Task<IBaseResponse<Drug>> Update(Drug drug)
    {
        var baseResponse = new BaseResponse<Drug>();
        if (drug == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _drugRepository.Update(drug);

        baseResponse.Data = drug;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}


