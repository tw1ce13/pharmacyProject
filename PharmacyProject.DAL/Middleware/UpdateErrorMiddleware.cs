using System;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Http;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Response;
using Newtonsoft.Json;

namespace PharmacyProject.DAL.Middleware
{
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
            ErrorResponse errorResponse = new ErrorResponse
            {
                StatusCode = StatusCode.Error,
                Message = ex.Message
            };
            switch (ex)
            {
                case DbUpdateException:
                    errorResponse = new ErrorResponse
                    {
                        StatusCode = StatusCode.Error,
                        Message = ex.Message,
                        Description = "Ошибка обновления"
                    };
                    break;
                case NullReferenceException:
                    errorResponse = new ErrorResponse
                    {
                        StatusCode = StatusCode.Error,
                        Message = ex.Message,
                        Description = "Ссылка на объект не указывает на экземпляр объекта"
                    };
                    break;
                default:
                    errorResponse = new ErrorResponse
                    {
                        StatusCode = StatusCode.Error,
                        Message = ex.Message,
                        Description = "Ошибка"
                    };
                    break;
            }
            var jsonError = JsonConvert.SerializeObject(errorResponse);
            await context.Response.WriteAsync(jsonError);
        }
    }

}

