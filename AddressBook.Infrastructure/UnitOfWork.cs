using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.Contact;
using AddressBook.Application.Interfaces.Location;
using AddressBook.Infrastructure.DbContexts;
using AddressBook.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AddressBookDbContext _context;
        public IContactRepository Contacts { get; }
        public ILocationRepository Locations { get; }

        public UnitOfWork(AddressBookDbContext context)
        {
            _context = context;
            Contacts = new ContactRepository(_context);
            Locations = new LocationRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
