using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.Configurations
{
    public class ImageProductConfiguration : IEntityTypeConfiguration<ImageProduct>
    {
        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.ToTable("ImageProducts");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.ImageProducts).HasForeignKey(x => x.ProductId);
        }
    }
}
