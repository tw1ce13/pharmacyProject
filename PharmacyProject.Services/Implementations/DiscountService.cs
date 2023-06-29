using PharmacyProject.DAL.Interfaces;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using PharmacyProject.Services.Response;

namespace PharmacyProject.Services.Implementations;

public class DiscountService : IDiscountService
{
    private readonly IBaseRepository<Discount> _discountRepository;



    public DiscountService(IBaseRepository<Discount> discountRepository)
    {
        _discountRepository = discountRepository;
    }


    public async Task<IBaseResponse<Discount>> Add(Discount discount)
    {
        await _discountRepository.Add(discount);
        var baseResponse = new BaseResponse<Discount>("Success", StatusCode.OK, discount);
        return baseResponse;
    }


    public async Task<IBaseResponse<Discount>> Delete(int id)
    {
        var discount = new Discount() { Id = id };
        await _discountRepository.Delete(discount);
        var baseResponse = new BaseResponse<Discount>("Success", StatusCode.OK, discount);
        return baseResponse;
    }


    public async Task<IBaseResponse<Discount>> Delete(Discount discount)
    {
        await _discountRepository.Delete(discount);
        var baseResponse = new BaseResponse<Discount>("Success", StatusCode.OK, discount);
        return baseResponse;
    }


    public async Task<IBaseResponse<Discount>> Get(int id, CancellationToken token)
    {
        var baseResponse = new BaseResponse<Discount>();
        var discount = await _discountRepository.GetById(id, token);
        if (discount == null)
        {
            baseResponse.Description = "Не найдено";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = discount;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;

    }


    public async Task<IBaseResponse<IEnumerable<Discount>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Discount>>();
        var discount = await _discountRepository.GetAll();
        if (discount == null)
        {
            baseResponse.Description = "Найдено 0 элементов";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        baseResponse.Data = discount;
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;
    }


    public async Task<IBaseResponse<Discount>> Update(Discount obj)
    {
        var baseResponse = new BaseResponse<Discount>();
        if (obj == null)
        {
            baseResponse.Description = "Объект не найден";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }


        await _discountRepository.Update(obj);

        baseResponse.Data = obj;
        baseResponse.Description = "успешно";
        baseResponse.StatusCode = StatusCode.OK;
        return baseResponse;

    }
}

