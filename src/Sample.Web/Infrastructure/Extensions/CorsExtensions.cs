namespace Microsoft.Extensions.DependencyInjection;

public class CorsOptions
{
    public const string SectionKey = "Cors";
    public string[] Urls { get; set; } = default!;
}

public static class CorsExtensions
{
    public const string CorsConfigId = "app";

    public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
    {
        var corsOptions = configuration.GetSection(CorsOptions.SectionKey).Get<CorsOptions>();
        return services.AddCors(o =>
        {
            o.AddPolicy(CorsConfigId, b =>
            {
                b.WithOrigins(corsOptions?.Urls ?? Array.Empty<string>())
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }

    public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
    {
        return app.UseCors(CorsConfigId);
    }
}
