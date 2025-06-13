using AddressBook.Shared.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactReadDto>> GetAllAsync();
        Task<ContactReadDto> GetByIdAsync(int id);
        Task CreateAsync(ContactWriteDto dto);
        Task UpdateAsync(int id, ContactWriteDto dto);
        Task DeleteAsync(int id);
    }
}
