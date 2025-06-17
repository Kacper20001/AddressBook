using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs.Location;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views
{
    /// <summary>
    /// Form used to collect data for creating a new contact.
    /// </summary>
    public partial class AddContactForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddContactForm"/> class.
        /// </summary>
        public AddContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets a new contact object based on the user's input in the form.
        /// </summary>
        public ContactWriteDto ContactToCreate => new ContactWriteDto
        {
            FirstName = firstNameTextBox.Text.Trim(),
            LastName = lastNameTextBox.Text.Trim(),
            BirthDate = birthDatePicker.Value.Date,
            PhoneNumber = phoneNumberTextBox.Text.Trim(),
            IsActive = isActiveCheckBox.Checked,
            LocationId = (int)(cityComboBox.SelectedValue ?? 0)
        };

        /// <summary>
        /// Loads the list of available locations into the city ComboBox.
        /// </summary>
        /// <param name="locations">The list of locations to populate the ComboBox.</param>
        public void LoadLocations(List<LocationReadDto> locations)
        {
            cityComboBox.DataSource = locations;
            cityComboBox.DisplayMember = "Display";
            cityComboBox.ValueMember = "Id";
        }
    }
}
