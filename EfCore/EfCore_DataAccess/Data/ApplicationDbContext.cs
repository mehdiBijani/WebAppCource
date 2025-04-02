using EfCore_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore_DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Genre> Genres { get; set; }
}