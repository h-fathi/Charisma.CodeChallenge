using Charisma.CodeChallenge.Domain.Entities.Orders;

namespace Charisma.CodeChallenge.Persistence.Configurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);
    }
}