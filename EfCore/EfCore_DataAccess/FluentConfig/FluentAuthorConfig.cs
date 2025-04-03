using EfCore_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore_DataAccess.FluentConfig;

public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
{
    public void Configure(EntityTypeBuilder<FluentAuthor> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(300);
        builder.Property(x => x.LastName).HasMaxLength(300);
        builder.Ignore(x => x.FullName);
    }
}