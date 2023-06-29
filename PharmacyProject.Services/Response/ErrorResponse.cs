using PharmacyProject.Domain.Enum;

namespace PharmacyProject.Services.Response;

public class ErrorResponse : BaseResponse<string>
{
    public ErrorResponse(string description, StatusCode statusCode, string message): base(description, statusCode, message)
    {

    }
}

