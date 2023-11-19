using Sample.Web.Features.Addresses.Dtos;

namespace Sample.Web.Features.Addresses;

internal static class DeleteAddress
{
    internal static Task<IResult> Handle(Guid id)
    {
        var address = Data.Addresses.FirstOrDefault(x => x.Id == id);
        if (address == null)
        {
            return Task.FromResult(Results.BadRequest());
        }

        Data.Addresses.Remove(address);

        return Task.FromResult(Results.Ok(address));
    }
}
