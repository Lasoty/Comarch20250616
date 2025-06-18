using Bibliotekarz.Data;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Borrowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(e => e.Autor)
            .IsRequired()
            .HasMaxLength(150)
            ;
    }
}
