using Charisma.CodeChallenge.Application.Products.GetProducts;

namespace Charisma.CodeChallenge.Application.Products;

internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;
    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDTO>> HandleAsync(GetProductsQuery command, CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetAll();
        return products.Select(x => new ProductDTO { Id = x.Id, Name = x.Name, Price = x.Price, ProfitMargin = x.ProfitMargin, StockQuantity = x.StockQuantity }).ToList();
    }
}
