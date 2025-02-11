using System.Net;
using System.Text.Json;
using WebApplication.Exceptions;

namespace WebApplication.GlobalExceptionHandler
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var (statusCode, errorCode) = GetErrorDetails(ex);

                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Message = ex.Message,
                    ErrorCode = errorCode
                };

                var result = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(result);
            }
        }

        private (HttpStatusCode, string) GetErrorDetails(Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errorCode = "InternalServerError";

            switch (ex)
            {
                case ShortLinkNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorCode = "ShortLinkNotFoundException";
                    break;

                case InvalidUrlException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = "InvalidUrlException";
                    break;

                default:
                    break;
            }

            return (statusCode, errorCode);
        }
    }
}
