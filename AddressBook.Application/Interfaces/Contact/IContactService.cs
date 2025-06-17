using AddressBook.Shared.DTOs.Contact;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces
{
    /// <summary>
    /// Interface defining business logic operations for contacts.
    /// </summary>
    public interface IContactService
    {
        /// <summary>Returns enriched contact data from a SQL view.</summary>
        Task<List<ContactViewResultDto>> GetAllFromViewAsync();

        /// <summary>Returns all contacts from the database.</summary>
        Task<List<ContactReadDto>> GetAllAsync();

        /// <summary>Returns a contact by its ID.</summary>
        /// <param name="id">The ID of the contact.</param>
        Task<ContactReadDto> GetByIdAsync(int id);

        /// <summary>Creates a new contact based on the provided data.</summary>
        /// <param name="dto">DTO containing new contact details.</param>
        Task CreateAsync(ContactWriteDto dto);

        /// <summary>Updates a contact with new values.</summary>
        /// <param name="id">ID of the contact to update.</param>
        /// <param name="dto">DTO with updated data.</param>
        Task UpdateAsync(int id, ContactWriteDto dto);

        /// <summary>Deletes the specified contact.</summary>
        /// <param name="id">ID of the contact to delete.</param>
        Task DeleteAsync(int id);
    }
}
