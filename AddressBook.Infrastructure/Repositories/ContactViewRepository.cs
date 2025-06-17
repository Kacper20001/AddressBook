using AddressBook.Application.Interfaces.ReadModels;
using AddressBook.Infrastructure.DbContexts;
using AddressBook.Shared.DTOs.Contact;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
    public class ContactViewRepository : IContactViewRepository
    {
        private readonly AddressBookDbContext _context;

        public ContactViewRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactViewResultDto>> GetAllAsync()
        {
            return await _context.ContactView.ToListAsync();
        }
    }
}
