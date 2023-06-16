using System;
using PharmacyProject.Domain.Enum;

namespace PharmacyProject.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public BaseResponse()
        {

        }
        public BaseResponse(string description, StatusCode statusCode, T data)
        {
            Description = description;
            StatusCode = statusCode;
            Data = data;
        }

        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
        
    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
}

