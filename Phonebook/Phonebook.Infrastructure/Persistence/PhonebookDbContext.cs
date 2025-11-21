using Microsoft.EntityFrameworkCore;
using Phonebook.Domain.Entities;

namespace Phonebook.Infrastructure.Persistence;

public class PhonebookDbContext : DbContext
{
    public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts => Set<Contact>();
}