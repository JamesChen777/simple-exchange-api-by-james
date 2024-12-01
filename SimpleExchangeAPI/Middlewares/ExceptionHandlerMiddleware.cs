using System.Net;
using Newtonsoft.Json;

namespace SimpleExchangeAPI.MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Global exception handler to handle all exceptions
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
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

        /// <summary>
        /// Global exception handler (core method) to handle all exceptions
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                exception = exception.Message,
                stackTrace = exception.StackTrace
            };

            // TBD: Logging logic
            // Can choose to use Microsoft.Extensions.Logging's logger or log4net, nLog, etc., etc.

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
