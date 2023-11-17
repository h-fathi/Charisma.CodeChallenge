namespace Charisma.CodeChallenge.Domain.Entities.Orders;

public interface IOrderRepository : IRepository
{
    Task Create(Order order);
}