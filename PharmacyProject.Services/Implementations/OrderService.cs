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


    public async Task<IBaseResponse<Order>> Add(Order order)
    {
        await _ordRepository.Add(order);
        var baseResponse = new BaseResponse<Order>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = order
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Delete(int id, CancellationToken token)
    {
        var order = await _ordRepository.GetById(id, token); 
        await _ordRepository.Delete(order);
        var baseResponse = new BaseResponse<Order>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = order
        }; ;
        return baseResponse;
    }


    public IBaseResponse<Order> DeleteRange(IEnumerable<Order> orders)
    {
        var order = new Order();
        var baseResponse = new BaseResponse<Order>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = order
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Delete(Order order)
    {
        await _ordRepository.Delete(order);
        var baseResponse = new BaseResponse<Order>
        {
            Description = "Success",
            StatusCode = StatusCode.OK,
            Data = order
        };
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Order>();
        var order = await _ordRepository.GetById(id, token);
        if (order == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = order;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<IEnumerable<Order>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Order>>();
        var orders = await _ordRepository.GetAll();
        if (orders == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = orders;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Order>> Update(Order order)
    {
        var baseResponse = new BaseResponse<Order>();
        if (order == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _ordRepository.Update(order);

        baseResponse.Data = order;
        baseResponse.Description = "Успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }
}

