namespace Charisma.CodeChallenge.Application.Products;

public class CreateProductCommand : ICommand
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public decimal ProfitMargin { get; set; }
}