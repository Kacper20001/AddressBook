using AddressBook.Application.Interfaces.Contact;
using AddressBook.Application.Interfaces.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IContactRepository Contacts { get; }
        ILocationRepository Locations { get; } 
        Task<int> SaveChangesAsync();
    }
}
