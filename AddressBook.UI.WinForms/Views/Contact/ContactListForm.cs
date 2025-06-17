using AddressBook.Application.Interfaces;
using AddressBook.Application.Interfaces.Location;
using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs.Location;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Utilities;
using AddressBook.UI.WinForms.Views;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms
{
    /// <summary>
    /// Main form used for managing the list of contacts.
    /// Implements the IContactView interface for MVP pattern.
    /// </summary>
    public partial class ContactListForm : Form, IContactView
    {
        private readonly IContactService _contactService;
        private readonly ILocationService _locationService;
        private readonly IValidator<LocationWriteDto> _locationValidator;
        private readonly IValidator<ContactWriteDto> _contactValidator;

        private List<ContactReadDto> _allContacts = new List<ContactReadDto>();
        private string _lastSortedColumn = "";
        private bool _sortAscending = true;

        /// <inheritdoc />
        public event EventHandler CreateClicked;

        /// <inheritdoc />
        public event EventHandler UpdateClicked;

        /// <inheritdoc />
        public event EventHandler DeleteClicked;

        /// <inheritdoc />
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactListForm"/> class.
        /// Wires UI events, configures sorting and filtering logic.
        /// </summary>
        /// <param name="contactService">Service for managing contacts.</param>
        /// <param name="locationService">Service for managing locations.</param>
        /// <param name="locationValidator">Validator for location DTO.</param>
        /// <param name="contactValidator">Validator for contact DTO.</param>
        public ContactListForm(IContactService contactService, ILocationService locationService, IValidator<LocationWriteDto> locationValidator, IValidator<ContactWriteDto> contactValidator)
        {
            _contactService = contactService;
            _locationService = locationService;
            _locationValidator = locationValidator;
            _contactValidator = contactValidator ?? throw new ArgumentNullException(nameof(contactValidator));
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
            };

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

        /// <inheritdoc />
        public List<ContactReadDto> Contacts
        {
            set
            {
                _allContacts = value;
                ApplyFilter();
            }
        }

        /// <inheritdoc />
        public int SelectedContactId
        {
            get
            {
                if (dataGridContacts.CurrentRow?.DataBoundItem is ContactReadDto contact)
                    return contact.Id;
                return -1;
            }
        }

        /// <inheritdoc />
        public ContactWriteDto ContactToCreate => new ContactWriteDto();

        /// <inheritdoc />
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <inheritdoc />
        public void ClearForm()
        {
            filterTextBox.Clear();
            dataGridContacts.ClearSelection();
        }

        /// <summary>
        /// Displays the edit contact form and saves changes if confirmed.
        /// </summary>
        /// <param name="contact">The contact to edit.</param>
        private async Task ShowEditForm(ContactReadDto contact)
        {
            try
            {
                var locations = await _locationService.GetAllAsync();

                using (var form = new EditContactForm(_contactValidator))
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

        /// <summary>
        /// Reloads all contacts from the service and updates the UI.
        /// </summary>
        private async Task ReloadContactsAsync()
        {
            var contacts = await _contactService.GetAllAsync();
            Contacts = contacts;
        }

        /// <summary>
        /// Applies text-based filtering to the contact list.
        /// Filters on Id, name, phone, postal code and city.
        /// </summary>
        private void ApplyFilter()
        {
            string filter = filterTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filter))
            {
                dataGridContacts.DataSource = _allContacts.ToList();
                dataGridContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return;
            }

            var filtered = _allContacts.Where(c =>
                c.Id.ToString().Contains(filter) ||
                c.FirstName.ToLower().Contains(filter) ||
                c.LastName.ToLower().Contains(filter) ||
                c.PhoneNumber.ToLower().Contains(filter) ||
                c.PostalCode.ToLower().Contains(filter) ||
                c.CityName.ToLower().Contains(filter)
            ).ToList();

            dataGridContacts.DataSource = filtered;
            dataGridContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        /// <summary>
        /// Configures additional settings for the DataGridView,
        /// including sort comparison logic.
        /// </summary>
        private void ConfigureDataGrid()
        {
            dataGridContacts.SortCompare += DataGridContacts_SortCompare;
        }

        /// <summary>
        /// Custom comparison logic for sorting DataGridView columns alphabetically.
        /// </summary>
        private void DataGridContacts_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = string.Compare(
                e.CellValue1?.ToString(),
                e.CellValue2?.ToString(),
                StringComparison.OrdinalIgnoreCase
            );
            e.Handled = true;
        }

        /// <summary>
        /// Opens the location management window using the FormNavigator.
        /// </summary>
        private void manageLocationsButton_Click(object sender, EventArgs e)
        {
            FormNavigator.ShowLocationForm(this);
        }
    }
}
