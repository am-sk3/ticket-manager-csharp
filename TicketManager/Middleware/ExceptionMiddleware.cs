using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicketManager.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await ExceptionResponse(ex, httpContext);
            }
        }

        private async Task ExceptionResponse(Exception exception, HttpContext httpContext)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            string errorCode;

            switch (exception)
            {
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorCode = "GENERIC_FAULT";
                    break;
            }

            var exceptionResponse = new
            {
                Status = response.StatusCode,
                ErrorCode = errorCode,
                Message = exception.Message
            };

            var result = JsonSerializer.Serialize(exceptionResponse);
            await response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
