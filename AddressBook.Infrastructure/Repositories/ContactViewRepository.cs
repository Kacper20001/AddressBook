using AddressBook.Application.Interfaces.ReadModels;
using AddressBook.Infrastructure.DbContexts;
using AddressBook.Shared.DTOs.Contact;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for retrieving data from the SQL view 'ContactView' using EF Core.
    /// </summary>
    public class ContactViewRepository : IContactViewRepository
    {
        private readonly AddressBookDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewRepository"/> class with the provided context.
        /// </summary>
        public ContactViewRepository(AddressBookDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public async Task<List<ContactViewResultDto>> GetAllAsync()
        {
            return await this._context.ContactView.ToListAsync();
        }
    }
}
