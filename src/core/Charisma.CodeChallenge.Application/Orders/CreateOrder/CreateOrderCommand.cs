using Charisma.CodeChallenge.Domain.Seedwork;
using Shared.Core.Contracts.ApplicationServices;

namespace Charisma.CodeChallenge.Application.Orders;

public class CreateOrderCommand : ICommand
{
    public long CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderLineDTO> OrderLines { get; set; } = new List<OrderLineDTO>();
    public OrderShippingMethod ShippingMethod { get; set; }
    public bool IsPackageFragile { get;  set; }
}
public enum OrderShippingMethod
{
    RegularPost,
    ExpressPost
}
public class OrderLineDTO
{
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}