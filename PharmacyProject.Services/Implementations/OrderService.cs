using PharmacyProject.Domain.Enum;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<Order> _ordRepository;
    public OrderService(IBaseRepository<Order> ordRepository)
    {
        _ordRepository = ordRepository;
    }


    public async Task<IBaseResponse<Order>> Add(Order ord)
    {
        await _ordRepository.Add(ord);
        var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, ord);
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Delete(int id)
    {
        var ord = new Order() { Id = id };
        await _ordRepository.Delete(ord);
        var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, ord);
        return baseResponse;
    }


    public IBaseResponse<Order> DeleteRange(IEnumerable<Order> orders)
    {
        var order = new Order();
        var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, order);
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Delete(Order ord)
    {
        await _ordRepository.Delete(ord);
        var baseResponse = new BaseResponse<Order>("Success", StatusCode.OK, ord);
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Order>();
        var ord = await _ordRepository.GetById(id, token);
        if (ord == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = ord;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Order>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Order>>();
        var ord = await _ordRepository.GetAll();
        if (ord == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = ord;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Update(Order obj)
    {
        var baseResponse = new BaseResponse<Order>();
        if (obj == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _ordRepository.Update(obj);

        baseResponse.Data = obj;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

