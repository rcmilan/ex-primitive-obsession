using ex_primitive_obsession.Models;
using Microsoft.EntityFrameworkCore;

namespace ex_primitive_obsession.Database;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id);

        modelBuilder.Entity<Book>().Property(b => b.Id)
            .HasConversion(bookId => bookId.Value, id => new BookId(id))
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Book>().Property(b => b.Title)
            .IsRequired();

        modelBuilder.Entity<Book>().Property(b => b.Culture)
            .HasConversion(new CultureInfoConverter());
    }
}
