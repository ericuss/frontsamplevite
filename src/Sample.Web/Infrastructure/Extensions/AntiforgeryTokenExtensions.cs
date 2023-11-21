using Microsoft.AspNetCore.Antiforgery;

namespace Microsoft.Extensions.DependencyInjection;

public static class AntiforgeryTokenExtensions
{
    public static IServiceCollection AddCustomAntiforgeryToken(this IServiceCollection services)
    {
        return services.AddAntiforgery();
    }

    public static IApplicationBuilder UseCustomAntiforgeryToken(this IApplicationBuilder app)
    {
        return app
                .UseMiddleware<ValidateAntiForgeryTokenMiddleware>()
                .UseMiddleware<AntiforgeryTokenGeneratorMiddleware>();
    }
}

public class ValidateAntiForgeryTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAntiforgery _antiforgery;

    public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
    {
        _next = next;
        _antiforgery = antiforgery;
    }

    public async Task Invoke(HttpContext context)
    {
        if (
            HttpMethods.IsPost(context.Request.Method)
            || HttpMethods.IsPatch(context.Request.Method)
            || HttpMethods.IsPut(context.Request.Method)
            || HttpMethods.IsDelete(context.Request.Method)
            )
        {
            await _antiforgery.ValidateRequestAsync(context);
        }

        await _next(context);
    }
}

public class AntiforgeryTokenGeneratorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAntiforgery _antiforgery;

    public AntiforgeryTokenGeneratorMiddleware(RequestDelegate next, IAntiforgery antiforgery)
    {
        _next = next;
        _antiforgery = antiforgery;
    }

    public Task Invoke(HttpContext context)
    {
        var requestPath = context.Request.Path.Value;

        // consider to apply in all get requests
        // if (string.Equals(requestPath, "/", StringComparison.OrdinalIgnoreCase)
        //     || string.Equals(requestPath, "/index.html", StringComparison.OrdinalIgnoreCase))
        if (HttpMethods.IsGet(context.Request.Method))
        {
            var tokenSet = _antiforgery.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
                new CookieOptions { HttpOnly = false });
        }

        return _next(context);
    }
}
