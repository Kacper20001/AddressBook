using AddressBook.Domain.Entities;
using AddressBook.Shared.DTOs.Location;
using AutoMapper;

namespace AddressBook.Shared.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between Location entity and Location DTOs.
    /// </summary>
    public class LocationProfile : Profile
    {
        /// <summary>
        /// Initializes the mapping configuration for Location and related DTOs.
        /// </summary>
        public LocationProfile()
        {
            CreateMap<Location, LocationReadDto>();
            CreateMap<LocationWriteDto, Location>();
        }
    }

}
