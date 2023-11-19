namespace Microsoft.Extensions.DependencyInjection;

public static class AddResponseHeadersExtensions
{
    public static IApplicationBuilder UseAcceptJsonHeader(this IApplicationBuilder app)
    {
        return app.Use(async (context, next) => {
            context.Response.Headers.Accept = "application/json";
            await next();
        });
    }

}
