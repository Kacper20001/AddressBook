using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.Location;
using AddressBook.Shared.DTOs.Contact;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Presenters
{
    public class ContactPresenter
    {
        private readonly IContactView _view;
        private readonly IContactService _contactService;
        private readonly ILocationService _locationService;

        public ContactPresenter(IContactView view, IContactService contactService, ILocationService locationService)
        {
            _view = view;
            _contactService = contactService;
            _locationService = locationService;

            _view.CreateClicked += async (s, e) => await ShowAddContactDialogAsync();
            _view.UpdateClicked += async (s, e) => await UpdateAsync();
            _view.DeleteClicked += async (s, e) => await DeleteAsync();
            _ = LoadAllAsync();
        }

        private async Task LoadAllAsync()
        {
            try
            {
                var contacts = await _contactService.GetAllFromViewAsync();
                //var contacts = await _contactService.GetAllAsync();
                _view.Contacts = contacts.Select(c => new ContactReadDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    BirthDate = c.BirthDate,
                    PhoneNumber = c.PhoneNumber,
                    IsActive = c.IsActive,
                    PostalCode = c.PostalCode,
                    CityName = c.CityName,
                    LocationId = 0
                }).ToList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Failed to load contacts: {ex.Message}");
            }
        }

        private async Task ShowAddContactDialogAsync()
        {
            var addForm = new AddContactForm();

            try
            {
                var locations = await _locationService.GetAllAsync();
                addForm.LoadLocations(locations);

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var contact = addForm.ContactToCreate;

                    if (contact == null)
                    {
                        _view.ShowMessage("No contact data provided.");
                        return;
                    }

                    await _contactService.CreateAsync(contact);
                    await LoadAllAsync();
                    _view.ShowMessage("Contact created successfully.");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error while creating contact: {ex.Message}");
            }
            finally
            {
                addForm.Dispose();
            }
        }

        private async Task UpdateAsync()
        {
            try
            {
                var contact = _view.ContactToCreate;

                if (contact == null)
                {
                    _view.ShowMessage("No contact selected.");
                    return;
                }

                await _contactService.UpdateAsync(_view.SelectedContactId, contact);
                await LoadAllAsync();
                _view.ClearForm();
                _view.ShowMessage("Contact updated successfully.");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error updating contact: {ex.Message}");
            }
        }

        private async Task DeleteAsync()
        {
            try
            {
                if (_view.SelectedContactId < 0)
                {
                    _view.ShowMessage("Please select a contact to delete.");
                    return;
                }

                var contacts = await _contactService.GetAllAsync();
                var selectedContact = contacts.FirstOrDefault(c => c.Id == _view.SelectedContactId);

                if (selectedContact == null)
                {
                    _view.ShowMessage("Selected contact not found.");
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete contact:\n\n{selectedContact.FirstName} {selectedContact.LastName} ({selectedContact.PhoneNumber})?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                await _contactService.DeleteAsync(selectedContact.Id);
                await LoadAllAsync();
                _view.ClearForm();
                _view.ShowMessage("Contact deleted successfully.");
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error deleting contact: {ex.Message}");
            }
        }
    }
}
