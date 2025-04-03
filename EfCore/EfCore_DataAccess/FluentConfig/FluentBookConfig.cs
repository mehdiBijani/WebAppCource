using EfCore_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore_DataAccess.FluentConfig;

public class FluentBookConfig:IEntityTypeConfiguration<FluentBook>
{
    public void Configure(EntityTypeBuilder<FluentBook> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(300);
        builder.Property(x => x.ISBN).HasMaxLength(50);
        builder.Ignore(x => x.PriceRange);
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.Category_id_fk);

        builder.HasOne(x => x.BookDetail)
            .WithOne(x => x.Book)
            .HasForeignKey<FluentBook>("BookDetail_id_fk");
        
        builder.HasOne(x => x.Publisher)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.Publisher_id_fk);
    }
}