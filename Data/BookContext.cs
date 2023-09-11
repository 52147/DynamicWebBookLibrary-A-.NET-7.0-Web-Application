using DynamicWebBookLibrary.Models;

namespace DynamicWebBookLibrary.Data
{
    using Microsoft.EntityFrameworkCore;

    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Book>().HasData(new Book
        //     {
        //         Id = 1,
        //         Title = "Example Title",
        //         Author = "Example Author",
        //     });
        // }
    }
}
