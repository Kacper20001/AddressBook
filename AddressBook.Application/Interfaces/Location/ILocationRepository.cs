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
    }
}
