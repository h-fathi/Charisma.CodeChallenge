using Charisma.CodeChallenge.Domain.Entities.Orders;

namespace Charisma.CodeChallenge.Persistence.Configurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);
        builder.OwnsMany(x => x.OrderLines, line =>
        {
            // Configure the table name and column names if necessary
            line.ToTable("OrderLines");
            line.HasKey(x => x.Id);
            line.Property(a => a.OrderId).IsRequired();
            line.Property(a => a.ProductId).IsRequired();
        }); ;
    }
}