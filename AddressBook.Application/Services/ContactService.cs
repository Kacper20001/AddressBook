using AddressBook.Application.Interfaces;
using AddressBook.Domain.Entities;
using AddressBook.Shared.DTOs.Contact;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ContactReadDto>> GetAllAsync()
        {
            var contacts = await _unitOfWork.Contacts.GetAllAsync();
            return _mapper.Map<List<ContactReadDto>>(contacts);
        }

        public async Task<ContactReadDto> GetByIdAsync(int id)
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
            return _mapper.Map<ContactReadDto>(contact);
        }

        public async Task CreateAsync(ContactWriteDto dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            await _unitOfWork.Contacts.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ContactWriteDto dto)
        {
            var existing = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (existing == null) return;

            _mapper.Map(dto, existing);
            await _unitOfWork.Contacts.UpdateAsync(existing);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _unitOfWork.Contacts.GetByIdAsync(id);
            if (existing == null) return;

            await _unitOfWork.Contacts.DeleteAsync(existing);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
