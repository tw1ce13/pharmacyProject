using PharmacyProject.Domain.Enum;

namespace PharmacyProject.Services.Response;

public class ErrorResponse : IBaseResponse
{
    public ErrorResponse()
    {
    }


    public string? Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public string Data { get; set; }
}

