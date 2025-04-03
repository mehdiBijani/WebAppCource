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
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookDetail> BookDetails { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<FluentCategory> FluentCategories { get; set; }
    public DbSet<FluentBook> FluentBooks { get; set; }
    public DbSet<FluentPublisher> FluentPublishers { get; set; }
    public DbSet<FluentAuthor> FluentAuthors { get; set; }
    public DbSet<FluentBookDetail> FluentBookDetails { get; set; }
    public DbSet<FluentBookAuthor> FluentBookAuthors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(b => new { b.Author_id_fk, b.Book_id_fk });
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}