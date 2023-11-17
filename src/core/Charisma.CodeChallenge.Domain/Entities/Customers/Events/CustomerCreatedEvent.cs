namespace Charisma.CodeChallenge.Domain.Entities.Customers.Events;

public class CustomerCreatedEvent : IDomainEvent
{
    private readonly Customer _customer;
    public CustomerCreatedEvent(Customer customer)
    {
        _customer = customer;
    }
    public DateTime OccurredOn => DateTime.Now;
}
