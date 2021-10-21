using HrApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HrApi.Extensions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException ex)
            {
                _logger.LogError($"A new violation exception was thrown: {ex}");
                await HandleExecption(httpContext, ex);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError($"A database concurrency exception was thrown: {ex}");
                await HandleExecption(httpContext, ex);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError("A division by zero exception was handled");
                await HandleExecption(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something was wrong: {ex}");
                await HandleExecption(httpContext, ex);
            }
        }
        public async Task HandleExecption(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var errorCode = (int)HttpStatusCode.InternalServerError;
            var message = "";
            switch (exception)
            {
                case AccessViolationException:
                    message = "Acces violation error from custom middleware";
                    break;
                case DivideByZeroException:
                    message = "Division by zero exception  handled from custom middleware";
                    errorCode = 422;
                    break;
                case DbUpdateConcurrencyException:
                    message = "Database concurrency exception handled from custom middlewar";
                    errorCode = 400;
                    break;
                default:
                    message = "Internal Server Error from custom middleware";
                    break;
            }
            context.Response.StatusCode = errorCode;
            await context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = message

            }.ToString());
        }
    }
}
