using AddressBook.Domain.Entities;
using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Mappings
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactReadDto>()
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Location.PostalCode))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Location.CityName));

            CreateMap<ContactWriteDto, Contact>();
        }
    }
}
