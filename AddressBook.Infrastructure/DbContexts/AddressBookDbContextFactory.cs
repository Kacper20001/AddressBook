using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace AddressBook.Infrastructure.DbContexts
{
    /// <summary>
    /// Factory used by EF Core during design-time to create <see cref="AddressBookDbContext"/>.
    /// </summary>
    public class AddressBookDbContextFactory : IDesignTimeDbContextFactory<AddressBookDbContext>
    {
        /// <summary>
        /// Creates a new instance of <see cref="AddressBookDbContext"/> using the connection string from configuration.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        /// <returns>New instance of <see cref="AddressBookDbContext"/>.</returns>
        public AddressBookDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AddressBookDbContext>();

            var connectionString = ConfigurationManager
                .ConnectionStrings["AddressBookDb"]
                .ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);

            return new AddressBookDbContext(optionsBuilder.Options);
        }
    }
}
