using Sample.Web.Features.Addresses;

namespace Sample.Web.Infrastructure.Http;

public static class Router
{
    const string baseRoute = "/api/v{version:apiVersion}";

    public static IEndpointRouteBuilder RegisterRoutes(this IEndpointRouteBuilder app)
    {
        var apiVersion = app.GetApiVersionSet();


        app.RegisterAddressessRoutes(baseRoute, apiVersion);

        return app;
    }
}

