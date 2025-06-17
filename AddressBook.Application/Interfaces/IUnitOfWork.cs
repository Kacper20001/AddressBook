using AddressBook.Application.Interfaces.Contact;
using AddressBook.Application.Interfaces.Location;
using System.Threading.Tasks;


namespace AddressBook.Application.Interfaces
{
    /// <summary>
    /// Represents a unit of work that coordinates repository operations and saving changes.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>Provides access to contact repository.</summary>
        IContactRepository Contacts { get; }

        /// <summary>Provides access to location repository.</summary>
        ILocationRepository Locations { get; }

        /// <summary>Saves all pending changes to the data store.</summary>
        Task<int> SaveChangesAsync();
    }
}
