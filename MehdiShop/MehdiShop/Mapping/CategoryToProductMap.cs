using MehdiShop.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MehdiShop.Mapping;

public class CategoryToProductMap : IEntityTypeConfiguration<CategoryToProduct>
{
    public void Configure(EntityTypeBuilder<CategoryToProduct> builder)
    {
        builder.HasKey(x => new { x.CategoryId, x.ProductId });
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.CategoryToProducts)
            .HasForeignKey(x => x.CategoryId);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.CategoryToProducts)
            .HasForeignKey(x => x.ProductId);
    }
}