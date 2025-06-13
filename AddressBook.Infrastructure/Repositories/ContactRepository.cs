using AddressBook.Domain.Entities;
using AddressBook.Application.Interfaces;
using AddressBook.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AddressBookDbContext _context;

        public ContactRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllAsync()
            => await _context.Contacts.Include(c => c.Location).ToListAsync();

        public async Task<Contact> GetByIdAsync(int id)
            => await _context.Contacts.Include(c => c.Location).FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Contact contact)
            => await _context.Contacts.AddAsync(contact);

        public Task UpdateAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
            return Task.CompletedTask;
        }
    }
}
