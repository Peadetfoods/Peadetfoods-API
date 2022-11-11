using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peadetfoods.Domain.Entities;

namespace Peadetfoods.Domain.EntityConfiguration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.Images).WithOne()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
