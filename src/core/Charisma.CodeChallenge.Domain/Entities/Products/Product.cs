namespace Charisma.CodeChallenge.Domain.Entities.Products;

public class Product : Entity, IAggregateRoot
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public decimal ProfitMargin { get; private set; }


    // ef
    private Product() { }

    // سازنده کلاس
    public Product(string name, decimal price, int quantity, decimal profitMargin)
    {
        SetName(name);
        SetPrice(price);
        StockQuantity = quantity; // مقدار اولیه موجودی
        ProfitMargin = profitMargin;
    }

    // تنظیم نام محصول
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        Name = name;
    }

    // تنظیم قیمت محصول
    public void SetPrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");

        Price = price;
    }

    // افزایش موجودی
    public void IncreaseStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative.");

        StockQuantity += quantity;
    }

    // کاهش موجودی
    public void DecreaseStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative.");

        if (StockQuantity < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        StockQuantity -= quantity;
    }

    public decimal GetPriceWithProfit()
    {
        return Price + ProfitMargin;
    }
}