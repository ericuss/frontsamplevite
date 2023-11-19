namespace Sample.Web.Features.Addresses;

internal static class GetAddress
{
    internal static Task<IResult> Handle(GetAddressParams p)
    {
        var address = Data.Addresses.FirstOrDefault(x => x.Id == p.Id);
        return Task.FromResult(Results.Ok(address));
    }
}
