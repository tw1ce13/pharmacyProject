using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Http;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Services.Response;
using Newtonsoft.Json;

namespace PharmacyProject.Services.Middleware;

public class UpdateErrorMiddleware
{
    private readonly RequestDelegate _next;

    public UpdateErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);
            await HandleUpdateErrorAsync(context, ex);
        }
    }

    private async Task HandleUpdateErrorAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)StatusCode.Error;
        var errorResponse = new ErrorResponse();
        switch (ex)
        {
            case DbUpdateException:
                errorResponse = new ErrorResponse()
                {
                    StatusCode = StatusCode.Error,
                    Data = ex.Message,
                    Description = "Update Error"
                };
                break;
            case NullReferenceException:
                errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCode.Error,
                    Data = ex.Message,
                    Description = "There is no such object"
                };
                break;
            case InvalidOperationException:
                errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCode.Error,
                    Data = ex.Message,
                    Description = "Invalid operation"
                };
                break;
            default:
                errorResponse = new ErrorResponse
                {
                    StatusCode = StatusCode.Error,
                    Data = ex.Message,
                    Description = "Error"
                };
                break;
        }
        var jsonError = JsonConvert.SerializeObject(errorResponse);
        await context.Response.WriteAsync(jsonError);
    }
}

