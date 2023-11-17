using Charisma.CodeChallenge.Domain.Entities.Orders;

namespace Charisma.CodeChallenge.Application.Orders;

internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        //create order
        var order = Order.Create(command.CustomerId, (ShippingMethod)command.ShippingMethod, command.IsPackageFragile);
        foreach (var item in command.OrderLines)
        {
            var product = await _productRepository.GetById(item.ProductId);
            if (product == null) return new Result("Product not found.");

            var lineResult = order.AddOrderLine(item.ProductId, item.Quantity, product.GetPriceWithProfit());
            if (!lineResult.IsSuccess)
            {
                return lineResult;
            }
        }

        //Apply discount
        order.ApplyDiscount(10000, 0);

        // validate order
        var result = order.IsValidOrder();
        if (!result.IsSuccess)
        {
            return result;
        }

        //Insert into db
        await _orderRepository.Create(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return new Result(true);
    }
}
