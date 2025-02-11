namespace WebApplication.GlobalExceptionHandler
{
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
