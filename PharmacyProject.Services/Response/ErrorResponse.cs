using System;
using PharmacyProject.Domain.Enum;

namespace PharmacyProject.Services.Response;

public class ErrorResponse
{
    public ErrorResponse()
    {
    }

    public string? Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public string? Message { get; set; }
}

