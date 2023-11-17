namespace Charisma.CodeChallenge.Persistence.Configurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

        builder.OwnsOne(x => x.Address, address =>
        {
   
            address.Property(a => a.Street).HasMaxLength(100).IsRequired();
            address.Property(a => a.City).HasMaxLength(50).IsRequired();
            address.Property(a => a.Country).HasMaxLength(50).IsRequired();

            // Configure the table name and column names if necessary
             address.ToTable("CustomerAddresses");
             address.Property(a => a.Street).HasColumnName("StreetName");
        });
    }
}