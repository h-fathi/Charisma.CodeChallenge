namespace Charisma.CodeChallenge.Domain.Entities.Products.Events;

public class ProductCreatedEvent : IDomainEvent
{
    private readonly Product _product;
    public ProductCreatedEvent(Product product)
    {
        _product = product;
    }
    public DateTime OccurredOn => DateTime.Now;
}
