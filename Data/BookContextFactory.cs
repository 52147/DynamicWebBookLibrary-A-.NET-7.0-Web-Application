using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DynamicWebBookLibrary.Data
{
    public class BookContextFactory : IDesignTimeDbContextFactory<BookContext>
    {
        public BookContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=book;User=root;Password=;", 
                                    new MySqlServerVersion(new Version(8, 0, 21)),
                                    x => x.MigrationsAssembly("DynamicWebBookLibrary"));

            return new BookContext(optionsBuilder.Options);
        }
    }
}
