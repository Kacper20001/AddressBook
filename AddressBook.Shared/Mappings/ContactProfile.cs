using AddressBook.Domain.Entities;
using AddressBook.Shared.DTOs.Contact;
using AutoMapper;

namespace AddressBook.Shared.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between Contact entity and Contact DTOs.
    /// </summary>
    public class ContactProfile : Profile
    {
        /// <summary>
        /// Initializes the mapping configuration for Contact and related DTOs.
        /// </summary>
        public ContactProfile()
        {
            // Mapping from Contact entity to ContactReadDto including nested Location data.
            CreateMap<Contact, ContactReadDto>()
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Location.PostalCode))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Location.CityName));

            // Mapping from ContactWriteDto to Contact entity.
            CreateMap<ContactWriteDto, Contact>();
        }
    }
}
