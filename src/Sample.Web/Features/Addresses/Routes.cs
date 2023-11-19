using System.Web.Http;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Sample.Web.Features.Addresses.Dtos;

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

        app.MapGet("{id}", ([AsParameters] GetAddressParams parameters) => GetAddress.Handle(parameters))
            .Produces(StatusCodes.Status200OK);


        app.MapPost(string.Empty, ([AsParameters] CreateAddressParams parameters) => UpsertAddress.Handle(parameters))
            .Produces(StatusCodes.Status200OK);

        app.MapPut("{id}", ([AsParameters] UpdateAddressParams parameters) => UpsertAddress.Handle(parameters))
            .Produces(StatusCodes.Status200OK);

        app.MapDelete("{id}", (Guid id) => DeleteAddress.Handle(id))
            .Produces(StatusCodes.Status200OK);

        return app;
    }
}

record struct GetAddressessParams();
record struct GetAddressParams(
    Guid Id
);

record struct CreateAddressParams(
   [FromBody] AddressDto Dto
);

record struct UpdateAddressParams(
    Guid Id,
    [FromBody] AddressDto Dto
);
