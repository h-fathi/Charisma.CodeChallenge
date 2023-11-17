using Charisma.CodeChallenge.Domain.Entities.Orders.Events;
namespace Charisma.CodeChallenge.Domain.Entities.Orders;

public class Order : Entity, IAggregateRoot
{
    public long Id { get; private set; }
    public long CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public decimal DiscountPercentage { get; private set; }
    public List<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();
    public decimal TotalAmount { get; private set; }
    public ShippingMethod ShippingMethod { get; private set; }
    public bool IsPackageFragile { get; private set; }

    #region Cunstractor
    // ef
    private Order() { }

    // سازنده کلاس
    public Order(long customerId, ShippingMethod shippingMethod, bool isPackageFragile)
    {
        CustomerId = customerId;
        ShippingMethod = shippingMethod;
        OrderDate = DateTime.UtcNow;
        IsPackageFragile = isPackageFragile;
        this.AddDomainEvent(new OrderCreatedEvent(this));
    }

    #endregion

    public static Order Create(long customerId, ShippingMethod shippingMethod, bool isPackageFragile)
    {
        var order = new Order(customerId, shippingMethod, isPackageFragile);
      
        return order;
    }


    // اضافه کردن خط سفارش
    public Result AddOrderLine(long productId, int quantity, decimal productPrice)
    {

        if (productId <= 0)
            return new Result("Product Id must be greater than zero.");
       
        if (productPrice <= 0)
            return new Result("Product Price must be greater than zero.");

        if (quantity <= 0)
            return new Result("Quantity must be greater than zero.");

        var orderLine = new OrderLine(productId, quantity, productPrice);
        OrderLines.Add(orderLine);
        UpdateTotalAmount();

        return new Result(true);
    }

    // حذف خط سفارش
    public Result RemoveOrderLine(OrderLine orderLine)
    {
        if (orderLine == null)
            return new Result(nameof(orderLine));

        OrderLines.Remove(orderLine);
        UpdateTotalAmount();
        return new Result(true);
    }

    // به روز رسانی خط سفارش
    public Result UpdateOrderLine(OrderLine orderLine, int quantity)
    {
        if (orderLine == null)
            return new Result(nameof(orderLine));

        if (quantity <= 0)
            return new Result("Quantity must be greater than zero.");

        orderLine.SetQuantity(quantity);
        UpdateTotalAmount();
        return new Result(true);
    }

    public Result ApplyDiscount(decimal amount, decimal percentage)
    {
        if (amount < 0 || percentage < 0 || percentage > 100)
            return new Result("Invalid discount values.");

        DiscountAmount = amount;
        DiscountPercentage = percentage;

        return new Result(true);
    }

    public decimal CalculateTotalAmount()
    {
        var total = OrderLines.Sum(ol => ol.Amount * ol.Quantity);
        var discount = (total * DiscountPercentage / 100) + DiscountAmount;
        return total - discount;
    }

    public Result IsValidOrder()
    {
        if (!OrderLines.Any())
            return new Result("The order must have at least one item");
        var result = IsValidOrderTime();
        if (!result.IsSuccess)
            return result;
        return IsValidOrderAmount();
    }

    private Result IsValidOrderTime()
    {
        var currentTime = DateTime.UtcNow; // یا هر زمان دیگر بسته به منطقه زمانی
        if(currentTime.Hour < 8 && currentTime.Hour > 19)
            return new Result("Order time is not valid.");

        return new Result(true);
    }

    private Result IsValidOrderAmount()
    {
        if (CalculateTotalAmount() < 500000)
            return new Result("Order amount is not valid.");

        return new Result(true);
    }

    private void UpdateTotalAmount()
    {
        TotalAmount = OrderLines.Sum(ol => ol.Amount * ol.Quantity);
    }

   
}