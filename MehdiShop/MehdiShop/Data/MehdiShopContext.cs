using MehdiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace MehdiShop.Data;

public class MehdiShopContext : DbContext
{
    public MehdiShopContext(DbContextOptions<MehdiShopContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    
    //Model Builder
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MehdiShopContext).Assembly);
    }
}