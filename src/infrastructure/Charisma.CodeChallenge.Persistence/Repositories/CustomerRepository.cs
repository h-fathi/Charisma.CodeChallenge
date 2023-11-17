namespace Charisma.CodeChallenge.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly OrderDbContext _orderDbContext;

    public CustomerRepository(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public async Task Create(Customer customer)
    {
        await _orderDbContext.Customers.AddAsync(customer);
    }
}