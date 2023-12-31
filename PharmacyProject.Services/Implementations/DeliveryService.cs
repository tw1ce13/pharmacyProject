﻿using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    public DeliveryService(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }


    public async Task<IBaseResponse<Delivery>> Add(Delivery delivery)
    {
        await _deliveryRepository.Add(delivery);
        var baseResponse = new BaseResponse<Delivery>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = delivery
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Delivery>> Delete(int id, CancellationToken token)
    {
        var delivery = await _deliveryRepository.GetById(id, token);
        await _deliveryRepository.Delete(delivery);
        var baseResponse = new BaseResponse<Delivery>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = delivery
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Delivery>> Delete(Delivery delivery)
    {
        await _deliveryRepository.Delete(delivery);
        var baseResponse = new BaseResponse<Delivery>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = delivery
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Delivery>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Delivery>();
        var delivery = await _deliveryRepository.GetById(id, token);
        if (delivery == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = delivery;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Delivery>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Delivery>>();
        var deliveries = await _deliveryRepository.GetAll();
        if (deliveries == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.NotFound;
            return baseResponse;
        }
        baseResponse.Data = deliveries;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Delivery>>> GetFresh()
    {
        var baseResponse = new BaseResponse<IEnumerable<Delivery>>();
        var deliveries = await _deliveryRepository.GetFresh();
        if (deliveries == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.NotFound;
            return baseResponse;
        }
        baseResponse.Data = deliveries;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Delivery>> Update(Delivery delivery)
    {
        var baseResponse = new BaseResponse<Delivery>();
        if (delivery == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _deliveryRepository.Update(delivery);

        baseResponse.Data = delivery;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

