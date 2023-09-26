using MehdiShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MehdiShop.Mapping;

public class ItemMap : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Product)
            .WithOne(x => x.Item)
            .HasForeignKey<Product>(x => x.ItemId);
    }
}