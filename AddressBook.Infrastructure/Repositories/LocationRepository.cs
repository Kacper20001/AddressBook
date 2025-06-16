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
        
        public async Task AddAsync(Location entity)
        {
            await _context.Locations.AddAsync(entity);
        }
       
        public async Task<Location> GetByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task UpdateAsync(Location entity)
        {
            _context.Locations.Update(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Location entity)
        {
            _context.Locations.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
