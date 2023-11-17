namespace Charisma.CodeChallenge.Application.Products;

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var product = new Product(command.Name, command.Price, command.StockQuantity, command.ProfitMargin);

        await _productRepository.Create(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Result(true);
    }
}
