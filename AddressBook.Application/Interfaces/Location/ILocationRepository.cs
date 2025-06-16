using AddressBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces.Location
{
    public interface ILocationRepository
    {
        Task<List<Domain.Entities.Location>> GetAllAsync();
        Task AddAsync(Domain.Entities.Location entity);
        Task<Domain.Entities.Location> GetByIdAsync(int id);
        Task UpdateAsync(Domain.Entities.Location entity);
        Task DeleteAsync(Domain.Entities.Location entity);


    }
}
