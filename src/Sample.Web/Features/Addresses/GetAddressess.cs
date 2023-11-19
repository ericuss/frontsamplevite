namespace Sample.Web.Features.Addresses;

internal static class GetAddressess
{
    internal static async Task<IResult> Handle(GetAddressessParams p)
    {
        return Results.Ok();
    }
}
