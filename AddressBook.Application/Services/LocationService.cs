using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.Location;
using AddressBook.Shared.DTOs.Location;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
    /// <summary>
    /// Provides business logic for managing locations.
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the LocationService class.
        /// </summary>
        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<List<LocationReadDto>> GetAllAsync()
        {
            var locations = await _unitOfWork.Locations.GetAllAsync();
            return _mapper.Map<List<LocationReadDto>>(locations);
        }

        /// <inheritdoc />
        public async Task AddAsync(LocationWriteDto dto)
        {
            var entity = _mapper.Map<Domain.Entities.Location>(dto);
            await _unitOfWork.Locations.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(int id, LocationWriteDto dto)
        {
            var entity = await _unitOfWork.Locations.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Location not found.");

            _mapper.Map(dto, entity);
            await _unitOfWork.Locations.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<LocationReadDto> GetByIdAsync(int id)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id);
            if (location == null)
                throw new Exception("Location not found.");

            return _mapper.Map<LocationReadDto>(location);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(id);
            if (location == null)
                throw new Exception("Location not found.");

            await _unitOfWork.Locations.DeleteAsync(location);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
