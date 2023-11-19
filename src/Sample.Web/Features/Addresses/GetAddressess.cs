namespace Sample.Web.Features.Addresses;

internal static class GetAddressess
{
    internal static Task<IResult> Handle(GetAddressessParams p)
    {
        return Task.FromResult(Results.Ok(Data.Addresses));
    }
}
