using System.Net;
using System.Text.Json;
using ContactAPI.Models;
using ContactAPI.Exceptions;

namespace ContactAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                await HandleException(context, ex.Message, 404);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception");
                await HandleException(context, "Something went wrong", 500);
            }
        }

        private async Task HandleException(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorResponse
            {
                Message = message,
                StatusCode = statusCode,
                Timestamp = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
