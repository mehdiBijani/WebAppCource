using EfCore_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore_DataAccess.FluentConfig;

public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
{
    public void Configure(EntityTypeBuilder<FluentBookAuthor> builder)
    {
        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.Book_id_fk);
        
        builder.HasOne(x => x.Author)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.Author_id_fk);
    }
}