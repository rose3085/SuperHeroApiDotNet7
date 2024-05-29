using SuperHeroApiDotNet7.Exceptions;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace SuperHeroApiDotNet7.Configurations
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware( RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            } 

        
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            var stackTrace = String.Empty;
            var message = "";

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(NotFoundException))
            {
                statusCode = HttpStatusCode.NotFound;
                stackTrace = ex.StackTrace;
                message = ex.Message;

            }
            else if (exceptionType == typeof(NotAuthorizedExceptions))
            {
                statusCode = HttpStatusCode.BadRequest;
                stackTrace = ex.StackTrace;
                message = ex.Message;

            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                stackTrace = ex.StackTrace;
                message = ex.Message;

            }


            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "/application/json";

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
