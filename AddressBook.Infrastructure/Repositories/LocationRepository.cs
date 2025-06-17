using AddressBook.Application.Interfaces.Location;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for accessing and modifying Location entities using EF Core.
    /// </summary>
    public class LocationRepository : ILocationRepository
    {
        private readonly AddressBookDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class with the provided database context.
        /// </summary>
        public LocationRepository(AddressBookDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public async Task<List<Location>> GetAllAsync()
            => await this._context.Locations.ToListAsync();

        /// <inheritdoc/>
        public async Task AddAsync(Location entity)
        {
            await this._context.Locations.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task<Location> GetByIdAsync(int id)
        {
            return await this._context.Locations.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Location entity)
        {
            this._context.Locations.Update(entity);
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Location entity)
        {
            this._context.Locations.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
