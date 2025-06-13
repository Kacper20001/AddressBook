using AddressBook.Shared.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Interfaces.Location
{
    public interface ILocationService
    {
        Task<List<LocationReadDto>> GetAllAsync();
    }
}
