using SimpleExchangeAPI.MiddleWares;

namespace SimpleExchangeAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseExceptionHandlingMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
