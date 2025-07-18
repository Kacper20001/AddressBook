﻿using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.ReadModels;
using AddressBook.Domain.Entities;
using AddressBook.Shared.DTOs.Contact;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
    /// <summary>
    /// Provides business logic for managing contacts.
    /// </summary>
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactViewRepository _contactViewRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the ContactService class.
        /// </summary>
        public ContactService(IUnitOfWork unitOfWork, IContactViewRepository contactViewRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _contactViewRepository = contactViewRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<List<ContactViewResultDto>> GetAllFromViewAsync()
        {
            var viewData = await _contactViewRepository.GetAllAsync();

            return viewData.Select(c => new ContactViewResultDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                BirthDate = c.BirthDate,
                PhoneNumber = c.PhoneNumber,
                IsActive = c.IsActive,
                PostalCode = c.PostalCode,
                CityName = c.CityName
            }).ToList();
        }

        /// <inheritdoc />
        public async Task<List<ContactReadDto>> GetAllAsync()
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync();
            return _mapper.Map<List<ContactReadDto>>(contacts);
        }

        /// <inheritdoc />
        public async Task<ContactReadDto> GetByIdAsync(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            return _mapper.Map<ContactReadDto>(contact);
        }

        /// <inheritdoc />
        public async Task CreateAsync(ContactWriteDto dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            await _unitOfWork.Contacts.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateAsync(int id, ContactWriteDto dto)
        {
            var existing = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (existing == null) return;

            _mapper.Map(dto, existing);
            await _unitOfWork.Contacts.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var existing = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (existing == null) return;

            await _unitOfWork.Contacts.DeleteAsync(existing);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
