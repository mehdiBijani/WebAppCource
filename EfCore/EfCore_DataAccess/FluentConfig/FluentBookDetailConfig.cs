using EfCore_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore_DataAccess.FluentConfig;

public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
{
    public void Configure(EntityTypeBuilder<FluentBookDetail> builder)
    {
        
    }
}