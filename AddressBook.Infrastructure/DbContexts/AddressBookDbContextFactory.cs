using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.DbContexts
{
    /// <summary>
    /// Factory used by EF Core during design-time to create AddressBookDbContext.
    /// </summary>
    public class AddressBookDbContextFactory : IDesignTimeDbContextFactory<AddressBookDbContext>
    {
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
