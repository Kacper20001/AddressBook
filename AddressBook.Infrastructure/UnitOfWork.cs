using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.Contact;
using AddressBook.Application.Interfaces.Location;
using AddressBook.Infrastructure.DbContexts;
using AddressBook.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure
{
    /// <summary>
    /// Provides a single point of coordination for working with multiple repositories and managing EF Core transactions.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AddressBookDbContext _context;

        /// <summary>
        /// Repository for contact-related operations.
        /// </summary>
        public IContactRepository Contacts { get; }

        /// <summary>
        /// Repository for location-related operations.
        /// </summary>
        public ILocationRepository Locations { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class with the provided database context.
        /// </summary>
        public UnitOfWork(AddressBookDbContext context)
        {
            this._context = context;
            this.Contacts = new ContactRepository(this._context);
            this.Locations = new LocationRepository(this._context);
        }

        /// <summary>
        /// Saves all pending changes in the database context.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        public async Task<int> SaveChangesAsync()
            => await this._context.SaveChangesAsync();
    }
}
