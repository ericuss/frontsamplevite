namespace Sample.Web.Features.Addresses
{

    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
    }

    public class Data
    {
        public static List<Address> Addresses;
        static Data()
        {
            Addresses = [
                new Address{ Street = "Street 1", City = "Bcn"}
            ];
        }
    }
}