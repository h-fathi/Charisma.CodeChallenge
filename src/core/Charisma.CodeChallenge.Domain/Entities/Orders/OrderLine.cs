namespace Charisma.CodeChallenge.Domain.Entities.Orders;

public class OrderLine : Entity
{
    public long Id { get; private set; }
    public long OrderId { get; private set; }
    public long ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }

    public OrderLine(long productId, int quantity, decimal amount)
    {
        ProductId = productId;
        Amount = amount;
        SetQuantity(quantity);
    }

    public Result SetQuantity(int quantity)
    {
        if (quantity <= 0)
            return new Result("Quantity must be greater than zero.");

        Quantity = quantity; 
        return new Result(true);
    }
    public Result SetPrice(decimal amount)
    {
        if (amount <= 0)
            return new Result("Amount must be greater than zero.");

        Amount = amount;
        return new Result(true);
    }
}