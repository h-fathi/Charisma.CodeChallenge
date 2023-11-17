namespace Charisma.CodeChallenge.Domain.Entities.Customers;

public class Customer : Entity, IAggregateRoot
{
    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Address Address { get; private set; }

    // ef
    private Customer() { }
    private Customer(string firstName, string lastName, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;

        this.AddDomainEvent(new CustomerCreatedEvent(this));
    }

    public static Customer Create(string firstName, string lastName, Address address)
    {
        var customer = new Customer(firstName, lastName, address);

        return customer;
    }
}