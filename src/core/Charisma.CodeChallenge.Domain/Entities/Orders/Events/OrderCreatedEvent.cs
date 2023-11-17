namespace Charisma.CodeChallenge.Domain.Entities.Orders.Events;

public class OrderCreatedEvent : IDomainEvent
{
    private readonly Order _order;
    public OrderCreatedEvent(Order order)
    {
        _order = order;
    }
    public DateTime OccurredOn => DateTime.Now;
}
