namespace Charisma.CodeChallenge.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OrderDbContext _orderDbContext;

    public ProductRepository(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }
    public async Task Create(Product product)
    {
        await _orderDbContext.Products.AddAsync(product);
    }

    public async Task<Product?> GetById(long id)
    {
       return await _orderDbContext.Products.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<List<Product>> GetAll()
    {
        return await _orderDbContext.Products.AsNoTracking().ToListAsync();
    }
}
