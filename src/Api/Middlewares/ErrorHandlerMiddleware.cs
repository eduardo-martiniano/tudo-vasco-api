using Core.Exceptions;
using System.Text.Json;

namespace Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                if (exception is DomainException)
                {
                    var domainException = (DomainException)exception;
                    var payload = new
                    {
                        errors = domainException.Errors
                    };

                    var response = context.Response;
                    response.ContentType = "application/json";
                    response.StatusCode = 400;

                    var result = JsonSerializer.Serialize(payload);
                    await response.WriteAsync(result);
                    return;
                }

                throw exception;
            }
        }
    }
}
    
