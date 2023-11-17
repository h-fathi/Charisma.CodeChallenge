namespace Charisma.CodeChallenge.Domain.Entities.Customers;

public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string country)
    {
        Street = street;
        City = city;
        Country = country;
    }
}