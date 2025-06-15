using AddressBook.Application.Interfaces.Location;
using AddressBook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Utilities;
using AddressBook.Shared.DTOs.Contact;
using AddressBook.UI.WinForms.Views;

namespace AddressBook.UI.WinForms
{
    public partial class ContactListForm : Form, IContactView
    {
        private readonly IContactService _contactService;
        private readonly ILocationService _locationService;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SelectionChanged;

        public ContactListForm(IContactService contactService, ILocationService locationService)
        {
            _contactService = contactService;
            _locationService = locationService;
            InitializeComponent();

            dataGridContacts.AutoGenerateColumns = false;
            ContactGridColumnBuilder.Configure(dataGridContacts);

            addContactButton.Click += (s, e) => CreateClicked?.Invoke(s, e);
            deleteContactButton.Click += (s, e) => DeleteClicked?.Invoke(s, e);
            dataGridContacts.SelectionChanged += (s, e) => SelectionChanged?.Invoke(s, e);

            editContactButton.Click += async (s, e) =>
            {
                if (dataGridContacts.CurrentRow?.DataBoundItem is ContactReadDto contact)
                {
                    await ShowEditForm(contact);
                }
            };
        }

        public List<ContactReadDto> Contacts
        {
            set => dataGridContacts.DataSource = value;
        }

        public int SelectedContactId
        {
            get
            {
                if (dataGridContacts.CurrentRow?.DataBoundItem is ContactReadDto contact)
                    return contact.Id;
                return -1;
            }
        }

        public ContactWriteDto ContactToCreate
        {
            get
            {
                return new ContactWriteDto(); //zaimplementować !!!
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ClearForm()
        {
            filterTextBox.Clear();
            dataGridContacts.ClearSelection();
        }

        private async Task ShowEditForm(ContactReadDto contact)
        {
            try
            {
                var locations = await _locationService.GetAllAsync();

                using (var form = new EditContactForm())
                {
                    form.LoadLocations(locations);
                    form.LoadContact(contact);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await _contactService.UpdateAsync(form.ContactId, form.UpdatedContact);
                        MessageBox.Show("Contact updated.");
                        await ReloadContactsAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing contact: {ex.Message}");
            }
        }

        private async Task ReloadContactsAsync()
        {
            var contacts = await _contactService.GetAllAsync();
            Contacts = contacts;
        }
    }
}
