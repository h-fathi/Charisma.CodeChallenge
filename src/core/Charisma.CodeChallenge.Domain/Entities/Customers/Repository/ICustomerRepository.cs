namespace Charisma.CodeChallenge.Domain.Entities.Customers;

public interface ICustomerRepository : IRepository
{
    Task Create(Customer customer);
}