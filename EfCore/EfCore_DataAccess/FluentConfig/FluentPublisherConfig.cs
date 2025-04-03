using EfCore_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore_DataAccess.FluentConfig;

public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
{
    public void Configure(EntityTypeBuilder<FluentPublisher> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(300);
        builder.Property(x => x.Location).HasMaxLength(300);
    }
}