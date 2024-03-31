using CaseRW.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseRW.Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tbl_rw_products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.StockQuantity).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
        }
    }
}
