using PharmacyProject.Domain.Enum;

namespace PharmacyProject.Services.Response;

public interface IBaseResponse
{
    string? Description { get; set; }
    StatusCode StatusCode { get; set; }
}

public interface IBaseResponse<T> : IBaseResponse
{
    T Data { get; set; }
}

public class BaseResponse<T> : IBaseResponse<T>
{
    public BaseResponse()
    {
    }

    public string? Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public T Data { get; set; }
}


