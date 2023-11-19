using Sample.Web.Features.Addresses.Dtos;

namespace Sample.Web.Features.Addresses;

internal static class UpsertAddress
{
    internal static Task<IResult> Handle(CreateAddressParams p)
    {
        var address = new Address()
        {
            Street = p.Dto.Street,
            City = p.Dto.City,

        };
        
        Data.Addresses.Add(address);

        return Task.FromResult(Results.Ok(address));
    }

    internal static Task<IResult> Handle(UpdateAddressParams p)
    {
        var address = Data.Addresses.FirstOrDefault(x => x.Id == p.Id);

        if (address == null)
        {
            return Task.FromResult(Results.BadRequest());
        }

        address.Street = p.Dto.Street;
        address.City = p.Dto.City;

        return Task.FromResult(Results.Ok(address));
    }
}
