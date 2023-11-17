namespace Charisma.CodeChallenge.Domain.Entities.Products;

public interface IProductRepository : IRepository
{
    Task Create(Product product);
    Task<Product> GetById(long id);
    Task<List<Product>> GetAll();
}