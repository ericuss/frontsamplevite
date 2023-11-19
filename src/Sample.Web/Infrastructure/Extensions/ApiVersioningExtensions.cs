using Asp.Versioning;
using Asp.Versioning.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApiVersioningExtensions
{
    public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
    {
        return services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = false;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();

        }).Services;
    }
    public static ApiVersionSet GetApiVersionSet(this IEndpointRouteBuilder app)
    {
        return app.NewApiVersionSet()
                    .HasApiVersion(new ApiVersion(1, 0))
                    .Build();
    }

}
