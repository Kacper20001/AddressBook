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
using AddressBook.Shared.DTOs.Location;

namespace AddressBook.UI.WinForms
{
    public partial class ContactListForm : Form, IContactView
    {
        private readonly IContactService _contactService;
        private readonly ILocationService _locationService;

        private List<ContactReadDto> _allContacts = new List<ContactReadDto>();

        private string _lastSortedColumn = "";
        private bool _sortAscending = true;

        public event EventHandler CreateClicked;
        public event EventHandler UpdateClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler SelectionChanged;

        public ContactListForm(IContactService contactService, ILocationService locationService)
        {
            _contactService = contactService;
            _locationService = locationService;
            InitializeComponent();

            ConfigureDataGrid();
            ContactGridColumnBuilder.Configure(dataGridContacts);

            addContactButton.Click += (s, e) => CreateClicked?.Invoke(s, e);
            deleteContactButton.Click += (s, e) => DeleteClicked?.Invoke(s, e);
            dataGridContacts.SelectionChanged += (s, e) => SelectionChanged?.Invoke(s, e);
            dataGridContacts.ColumnHeaderMouseClick += (s, e) =>
            {
                string columnName = dataGridContacts.Columns[e.ColumnIndex].DataPropertyName;
                if (string.IsNullOrWhiteSpace(columnName)) return;

                if (_lastSortedColumn == columnName)
                    _sortAscending = !_sortAscending;
                else
                    _sortAscending = true;

                _lastSortedColumn = columnName;

                var sorted = _sortAscending
                    ? _allContacts.OrderBy(c => c.GetType().GetProperty(columnName)?.GetValue(c, null)).ToList()
                    : _allContacts.OrderByDescending(c => c.GetType().GetProperty(columnName)?.GetValue(c, null)).ToList();

                dataGridContacts.DataSource = sorted;
            }; ;


            editContactButton.Click += async (s, e) =>
            {
                if (dataGridContacts.CurrentRow?.DataBoundItem is ContactReadDto contact)
                {
                    await ShowEditForm(contact);
                }
            };

            filterTextBox.TextChanged += (s, e) => ApplyFilter();
            clearFilterButton.Click += (s, e) =>
            {
                filterTextBox.Clear();
                ApplyFilter();
            };
        }

        public List<ContactReadDto> Contacts
        {
            set
            {
                _allContacts = value;
                ApplyFilter();
            }
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

        public ContactWriteDto ContactToCreate => new ContactWriteDto();

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
                var locations = await _locationService.GetAllLocations();

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

        private void ApplyFilter()
        {
            string filter = filterTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filter))
            {
                dataGridContacts.DataSource = _allContacts.ToList();
                return;
            }

            var filtered = _allContacts.Where(c =>
                c.FirstName.ToLower().Contains(filter) ||
                c.LastName.ToLower().Contains(filter) ||
                c.PhoneNumber.ToLower().Contains(filter) ||
                c.PostalCode.ToLower().Contains(filter) ||
                c.CityName.ToLower().Contains(filter)
            ).ToList();

            dataGridContacts.DataSource = filtered;
        }

        private void ConfigureDataGrid()
        {
            dataGridContacts.SortCompare += DataGridContacts_SortCompare;
        }

        private void DataGridContacts_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = string.Compare(
                e.CellValue1?.ToString(),
                e.CellValue2?.ToString(),
                StringComparison.OrdinalIgnoreCase
            );
            e.Handled = true;
        }

    }
}
