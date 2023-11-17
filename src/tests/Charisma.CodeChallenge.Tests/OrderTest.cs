using FluentAssertions;

namespace Charisma.CodeChallenge.Tests;

public class OrderTest
{

    [Fact]
    public void AddOrderLine_ShouldAddOrderLineAndUpdateTotalAmount()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        var productId = 2;
        var quantity = 3;
        var productPrice = 10;

        // Act
        var result = order.AddOrderLine(productId, quantity, productPrice);

        // Assert
        result.IsSuccess.Should().BeTrue();
        order.OrderLines.Should().HaveCount(1);
        order.TotalAmount.Should().Be(quantity * productPrice);
    }

    [Fact]
    public void RemoveOrderLine_ShouldRemoveOrderLineAndUpdateTotalAmount()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        var orderLine = new OrderLine(2, 3, 10);
        order.OrderLines.Add(orderLine);

        // Act
        var result = order.RemoveOrderLine(orderLine);

        // Assert
        result.IsSuccess.Should().BeTrue();
        order.OrderLines.Should().BeEmpty();
        order.TotalAmount.Should().Be(0);
    }

    [Fact]
    public void UpdateOrderLine_ShouldUpdateOrderLineAndTotalAmount()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        var orderLine = new OrderLine(2, 3, 10);
        order.OrderLines.Add(orderLine);
        var newQuantity = 5;

        // Act
        var result = order.UpdateOrderLine(orderLine, newQuantity);

        // Assert
        result.IsSuccess.Should().BeTrue();
        orderLine.Quantity.Should().Be(newQuantity);
        order.TotalAmount.Should().Be(newQuantity * orderLine.Amount);
    }

    [Fact]
    public void ApplyDiscount_ShouldApplyDiscountAndAdjustTotalAmount()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        var discountAmount = 5;
        var discountPercentage = 10;

        // Act
        var result = order.ApplyDiscount(discountAmount, discountPercentage);

        // Assert
        result.IsSuccess.Should().BeTrue();
        order.DiscountAmount.Should().Be(discountAmount);
        order.DiscountPercentage.Should().Be(discountPercentage);
    }

    [Fact]
    public void IsValidOrder_ShouldReturnTrueForValidOrder()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        order.AddOrderLine(2, 3, 10); // Add a sample order line

        // Act
        var result = order.IsValidOrder();

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void IsValidOrder_ShouldReturnFalseForInvalidOrderTime()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        order.AddOrderLine(2, 3, 10);

        // Set order time to an invalid time (e.g., late at night)
        var currentTime = DateTime.UtcNow;
        order.GetType().GetProperty("OrderDate").SetValue(order, currentTime.Date.AddHours(23));

        // Act
        var result = order.IsValidOrder();

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void IsValidOrder_ShouldReturnFalseForInvalidOrderAmount()
    {
        // Arrange
        var order = Order.Create(1, ShippingMethod.RegularPost, false);
        order.AddOrderLine(1, 2, 100);

        // Act
        var result = order.IsValidOrder();

        // Assert
        result.IsSuccess.Should().BeFalse();
    }

}