using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Domain.Entities;

namespace AddressBook.Application.Interfaces.Contact
{
    public interface IContactRepository
    {
        Task<List<Domain.Entities.Contact>> GetAllAsync();
        Task<Domain.Entities.Contact> GetByIdAsync(int id);
        Task AddAsync(Domain.Entities.Contact contact);
        Task UpdateAsync(Domain.Entities.Contact contact);
        Task DeleteAsync(Domain.Entities.Contact contact);
    }
}
