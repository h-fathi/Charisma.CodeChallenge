namespace Charisma.CodeChallenge.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _orderDbContext;

    public OrderRepository(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task Create(Order order)
    {
        await _orderDbContext.Orders.AddAsync(order);
    }
}