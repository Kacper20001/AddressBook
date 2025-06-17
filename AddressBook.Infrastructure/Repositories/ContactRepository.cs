using AddressBook.Application.Interfaces.Contact;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AddressBook.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for accessing and modifying Contact entities using EF Core.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class with the provided database context.
        /// </summary>
        public ContactRepository(AddressBookDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public async Task<List<Contact>> GetAllAsync()
            => await this._context.Contacts.Include(c => c.Location).ToListAsync();

        /// <inheritdoc/>
        public async Task<Contact> GetByIdAsync(int id)
            => await this._context.Contacts.Include(c => c.Location).FirstOrDefaultAsync(c => c.Id == id);

        /// <inheritdoc/>
        public async Task AddAsync(Contact contact)
            => await this._context.Contacts.AddAsync(contact);

        /// <inheritdoc/>
        public Task UpdateAsync(Contact contact)
        {
            this._context.Contacts.Update(contact);
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task DeleteAsync(Contact contact)
        {
            this._context.Contacts.Remove(contact);
            return Task.CompletedTask;
        }
    }
}
