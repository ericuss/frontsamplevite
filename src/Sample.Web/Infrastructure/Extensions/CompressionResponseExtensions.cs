using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Microsoft.Extensions.DependencyInjection;

public static class CompressionResponseExtensions
{
    public static IServiceCollection AddCustomCompressionResponse(this IServiceCollection services)
    {
        return services
                .AddResponseCompression(o =>
                {
                    o.EnableForHttps = true;
                    o.Providers.Add<GzipCompressionProvider>();
                })
                .Configure<GzipCompressionProviderOptions>(o =>
                {
                    o.Level = CompressionLevel.Fastest;
                });
    }

    public static IApplicationBuilder UseCustomCompressionResponse(this IApplicationBuilder app)
    {
        return app.UseResponseCompression();
    }
}
