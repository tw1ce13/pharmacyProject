using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class PharmacyService : IPharmacyService
{
    private readonly IBaseRepository<Pharmacy> _pharmacyRepository;
    public PharmacyService(IBaseRepository<Pharmacy> pharmacyRepository)
    {
        _pharmacyRepository = pharmacyRepository;
    }


    public async Task<IBaseResponse<Pharmacy>> Add(Pharmacy pharmacy)
    {
        await _pharmacyRepository.Add(pharmacy);
        var baseResponse = new BaseResponse<Pharmacy>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = pharmacy
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Pharmacy>> Delete(int id, CancellationToken token)
    {
        var pharmacy = await _pharmacyRepository.GetById(id, token);
        await _pharmacyRepository.Delete(pharmacy);
        var baseResponse = new BaseResponse<Pharmacy>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = pharmacy
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Pharmacy>> Delete(Pharmacy pharmacy)
    {
        await _pharmacyRepository.Delete(pharmacy);
        var baseResponse = new BaseResponse<Pharmacy>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = pharmacy
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Pharmacy>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Pharmacy>();
        var pharmacy = await _pharmacyRepository.GetById(id, token);
        if (pharmacy == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = pharmacy;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Pharmacy>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Pharmacy>>();
        var pharmacies = await _pharmacyRepository.GetAll();
        if (pharmacies == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = pharmacies;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Pharmacy>> Update(Pharmacy pharmacy)
    {
        var baseResponse = new BaseResponse<Pharmacy>();
        if (pharmacy == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }

        await _pharmacyRepository.Update(pharmacy);

        baseResponse.Data = pharmacy;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

