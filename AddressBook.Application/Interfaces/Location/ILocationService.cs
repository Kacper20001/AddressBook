using AddressBook.Shared.DTOs.Location;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces.Location
{
    /// <summary>
    /// Interface defining location-related application logic.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>Retrieves all locations.</summary>
        Task<List<LocationReadDto>> GetAllAsync();

        /// <summary>Retrieves a location by its ID.</summary>
        /// <param name="id">The location ID.</param>
        Task<LocationReadDto> GetByIdAsync(int id);

        /// <summary>Adds a new location based on the DTO.</summary>
        /// <param name="dto">Location data to insert.</param>
        Task AddAsync(LocationWriteDto dto);

        /// <summary>Updates a location with new data.</summary>
        /// <param name="id">ID of the location to update.</param>
        /// <param name="dto">Updated location values.</param>
        Task UpdateAsync(int id, LocationWriteDto dto);

        /// <summary>Deletes the specified location.</summary>
        /// <param name="id">ID of the location to delete.</param>
        Task DeleteAsync(int id);
    }
}
