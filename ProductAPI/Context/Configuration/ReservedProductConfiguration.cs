using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductApi.Context.Configurations
{
    public class ReservedProductConfiguration : IEntityTypeConfiguration<ReservedProduct>
    {
        public void Configure(EntityTypeBuilder<ReservedProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.ReservedProducts)
                .HasForeignKey(x => x.ProductId);
                
            builder
                .HasOne(x => x.Client)
                .WithMany(x => x.ReservedProducts)
                .HasForeignKey(x => x.ClientId);
        }
    }
}