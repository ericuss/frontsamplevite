using Asp.Versioning;
using Asp.Versioning.Builder;

namespace Sample.Web.Features.Addresses;

public static class AddressessRoutes
{
    public static IEndpointRouteBuilder RegisterAddressessRoutes(this IEndpointRouteBuilder app, string baseRoute, ApiVersionSet apiVersionSet)
    {
        return app.MapGroup(baseRoute + "/addressess")
                    .WithApiVersionSet(apiVersionSet)
                    .HasApiVersion(new ApiVersion(1))
                    .GroupedByOpenApiTag("Addressess")
                    .MapAddressessEndpoints();
    }

    private static IEndpointRouteBuilder MapAddressessEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(string.Empty, ([AsParameters] GetAddressessParams parameters) => GetAddressess.Handle(parameters))
            .Produces(StatusCodes.Status200OK);

        return app;
    }
}

record struct GetAddressessParams();
