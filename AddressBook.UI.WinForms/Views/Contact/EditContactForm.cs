using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs.Location;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views
{
    /// <summary>
    /// Form used for editing an existing contact.
    /// </summary>
    public partial class EditContactForm : Form
    {
        private int _contactId;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditContactForm"/> class.
        /// </summary>
        public EditContactForm()
        {
            InitializeComponent();
            saveButton.Click += (s, e) => DialogResult = DialogResult.OK;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Loads location data into the city ComboBox.
        /// </summary>
        /// <param name="locations">The list of locations to load.</param>
        public void LoadLocations(List<LocationReadDto> locations)
        {
            cityComboBox.DataSource = locations;
            cityComboBox.DisplayMember = "Display";
            cityComboBox.ValueMember = "Id";
        }

        /// <summary>
        /// Loads contact data into the form for editing.
        /// </summary>
        /// <param name="dto">The contact to edit.</param>
        public void LoadContact(ContactReadDto dto)
        {
            _contactId = dto.Id;
            firstNameTextBox.Text = dto.FirstName;
            lastNameTextBox.Text = dto.LastName;
            birthDatePicker.Value = dto.BirthDate;
            phoneNumberTextBox.Text = dto.PhoneNumber;
            isActiveCheckBox.Checked = dto.IsActive;
            cityComboBox.SelectedValue = dto.LocationId;
        }

        /// <summary>
        /// Gets the ID of the contact being edited.
        /// </summary>
        public int ContactId => _contactId;

        /// <summary>
        /// Gets the updated contact object with data from the form.
        /// </summary>
        public ContactWriteDto UpdatedContact => new ContactWriteDto
        {
            FirstName = firstNameTextBox.Text.Trim(),
            LastName = lastNameTextBox.Text.Trim(),
            BirthDate = birthDatePicker.Value.Date,
            PhoneNumber = phoneNumberTextBox.Text.Trim(),
            IsActive = isActiveCheckBox.Checked,
            LocationId = (int)(cityComboBox.SelectedValue ?? 0)
        };
    }
}
