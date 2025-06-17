using AddressBook.Shared.DTOs.Contact;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AddressBook.Application.Interfaces.ReadModels
{
    /// <summary>
    /// Provides access to contact data from a database view.
    /// </summary>
    public interface IContactViewRepository
    {
        /// <summary>Gets all contacts from the SQL view.</summary>
        Task<List<ContactViewResultDto>> GetAllAsync();
    }
}
