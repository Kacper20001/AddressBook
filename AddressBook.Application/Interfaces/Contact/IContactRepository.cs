using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces.Contact
{
    /// <summary>
    /// Interface for accessing and managing contact entities in the data source.
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>Retrieves all contacts.</summary>
        Task<List<Domain.Entities.Contact>> GetAllAsync();

        /// <summary>Gets a contact by ID.</summary>
        /// <param name="id">Unique identifier of the contact.</param>
        Task<Domain.Entities.Contact> GetByIdAsync(int id);

        /// <summary>Adds a new contact entity.</summary>
        /// <param name="contact">The contact to add.</param>
        Task AddAsync(Domain.Entities.Contact contact);

        /// <summary>Updates an existing contact entity.</summary>
        /// <param name="contact">The contact to update.</param>
        Task UpdateAsync(Domain.Entities.Contact contact);

        /// <summary>Deletes a contact entity.</summary>
        /// <param name="contact">The contact to delete.</param>
        Task DeleteAsync(Domain.Entities.Contact contact);
    }
}
