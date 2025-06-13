using AddressBook.Application.Interfaces.Location;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AddressBookDbContext _context;

        public LocationRepository(AddressBookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAllAsync()
            => await _context.Locations.ToListAsync();
    }
}
