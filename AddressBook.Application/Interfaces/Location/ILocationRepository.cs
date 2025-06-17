using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces.Location
{
    /// <summary>
    /// Interface for CRUD operations on location entities.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>Gets all locations from the data store.</summary>
        Task<List<Domain.Entities.Location>> GetAllAsync();

        /// <summary>Adds a new location entity.</summary>
        /// <param name="entity">The location to add.</param>
        Task AddAsync(Domain.Entities.Location entity);

        /// <summary>Gets a location by its ID.</summary>
        /// <param name="id">Location identifier.</param>
        Task<Domain.Entities.Location> GetByIdAsync(int id);

        /// <summary>Updates a location entity.</summary>
        /// <param name="entity">Updated location data.</param>
        Task UpdateAsync(Domain.Entities.Location entity);

        /// <summary>Deletes a location entity.</summary>
        /// <param name="entity">The location to remove.</param>
        Task DeleteAsync(Domain.Entities.Location entity);
    }
}
