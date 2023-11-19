using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;
using Sample.Web.Infrastructure.Extensions.SwaggerFiles;


namespace Microsoft.Extensions.DependencyInjection;

public static class OpenApiExtensions
{
    //public const string CorsConfigId = "app";

    //public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
    //{
    //    var corsOptions = configuration.GetSection(CorsOptions.SectionKey).Get<CorsOptions>();
    //    return services.AddCors(o =>
    //    {
    //        o.AddPolicy(CorsConfigId, b =>
    //        {
    //            b.WithOrigins(corsOptions?.Urls ?? Array.Empty<string>())
    //                .AllowAnyHeader()
    //                .AllowAnyMethod();
    //        });
    //    });
    //}

    //public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
    //{
    //    return app.UseCors(CorsConfigId);
    //}

    private static string GetVersion(string versionKey)
        => versionKey.ToLowerInvariant().Contains('v') ? versionKey : $"V{versionKey}";

#pragma warning disable CS8602 // Dereference of a possibly null reference.
    private static readonly Func<Type, string> _customSchemaIdsDefaultTemplate =
        x => $"{x.Namespace.Replace($"{x.Assembly.GetName().Name}.", string.Empty)}_{x.Name}";
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    private readonly static Dictionary<string, string> apiVersions = new Dictionary<string, string> { { "V1", "Sample API V1" } };

    public static IServiceCollection AddCustomOpenApi(this IServiceCollection services)
    {
        var groupByTag = true;
        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(o =>
            {
                //o.SwaggerDoc("v1", new OpenApiInfo { Title = "API ", Version = "v1" });
                //o.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                o.CustomSchemaIds(_customSchemaIdsDefaultTemplate);
                o.DocInclusionPredicate((docName, api) => api.RelativePath.StartsWith("api"));
                if (groupByTag) o.TagActionsBy(api => new[] { api.GroupName! });

                o.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();

                foreach (var version in apiVersions)
                {
                    var versionParameter = GetVersion(version.Key);
                    o.SwaggerDoc(
                        versionParameter,
                        new OpenApiInfo
                        {
                            Title = version.Value,
                            Version = versionParameter
                        });
                }

            });
    }


    public static IApplicationBuilder UseCustomOpenApi(this IApplicationBuilder app)
    {
        return app.UseSwagger(c =>
        {

        })
            .UseSwaggerUI(c =>
            {

                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                foreach (var version in apiVersions)
                {
                    var versionParameter = GetVersion(version.Key);
                    c.SwaggerEndpoint($"{versionParameter}/swagger.json", version.Value);
                }
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
    }

    public static IApplicationBuilder UseCustomRedirectFromHomeToOpenApi(this IApplicationBuilder app)
    {
        var options = new RewriteOptions();
        options.AddRedirect("^$", "swagger");
        return app.UseRewriter(options);
    }

    public static RouteGroupBuilder GroupedByOpenApiTag(this RouteGroupBuilder builder, string name)
    {
        return builder
            .WithOpenApi(operation => new(operation)
            {
                Tags = new List<OpenApiTag> { new() { Name = name } }
            });
    }
}
