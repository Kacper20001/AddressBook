using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.DTOs.Location
{
    public class LocationReadDto
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }

        public string Display => $"{CityName} ({PostalCode})";

    }
}
