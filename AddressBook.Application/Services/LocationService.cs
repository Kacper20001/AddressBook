using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.Location;
using AddressBook.Shared.DTOs.Location;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LocationReadDto>> GetAllAsync()
        {
            var locations = await _unitOfWork.Locations.GetAllAsync();
            return _mapper.Map<List<LocationReadDto>>(locations);
        }
    }
}
