﻿
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class AvailabilityService : IAvailabilityService
{
    private readonly IAvailabilityRepository _availabilityRepository;



    public AvailabilityService(IAvailabilityRepository availabilityRepository)
    {
        _availabilityRepository = availabilityRepository;
    }


    public async Task<IBaseResponse<Availability>> Add(Availability availability)
    {
        await _availabilityRepository.Add(availability);
        var baseResponse = new BaseResponse<Availability>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = availability
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Availability>> Delete(int id, CancellationToken token)
    {
        var availability = await _availabilityRepository.GetById(id, token);
        await _availabilityRepository.Delete(availability);
        var baseResponse = new BaseResponse<Availability>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = availability
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Availability>> Delete(Availability availability)
    {
        await _availabilityRepository.Delete(availability);
        var baseResponse = new BaseResponse<Availability>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = availability
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Availability>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Availability>();
        var availability = await _availabilityRepository.GetById(id, token);

        if (availability == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }

        baseResponse.Data = availability;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Availability>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Availability>>();
        var availabilities = await _availabilityRepository.GetAll();
        if (availabilities == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = availabilities;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilitiesByPharmacyId(int pharmacyId)
    {
        var baseResponse = new BaseResponse<IEnumerable<Availability>>();
        var availabilities = await _availabilityRepository.GetAvailabilitiesByPharmacyId(pharmacyId);
        if (availabilities == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.ObjectNotFound;
            return baseResponse;
        }
        baseResponse.Data = availabilities;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilitiesByDelivery(IEnumerable<int> deliveriesId)
    {
        var baseResponse = new BaseResponse<IEnumerable<Availability>>();
        var availabilities = await _availabilityRepository.GetAvailabilitiesByDelivery(deliveriesId);
        if (availabilities == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.ObjectNotFound;
            return baseResponse;
        }
        baseResponse.Data = availabilities;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Availability>> Update(Availability availability)
    {
        var baseResponse = new BaseResponse<Availability>();
        if (availability == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }

        await _availabilityRepository.Update(availability);

        baseResponse.Data = availability;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}


