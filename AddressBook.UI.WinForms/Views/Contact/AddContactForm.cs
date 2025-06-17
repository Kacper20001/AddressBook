using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs.Location;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views
{
    /// <summary>
    /// Form used to collect data for creating a new contact.
    /// </summary>
    public partial class AddContactForm : Form
    {
        private readonly IValidator<ContactWriteDto> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddContactForm"/> class.
        /// Sets up event handlers for Save and Cancel buttons.
        /// </summary>
        /// <param name="validator">Validator used to validate contact input.</param>
        public AddContactForm(IValidator<ContactWriteDto> validator)
        {
            _validator = validator;
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Gets the contact data to create after the form is submitted.
        /// </summary>
        public ContactWriteDto ContactToCreate { get; private set; }

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

        /// <summary>
        /// Handles the Save button click, validates the input, and sets the ContactToCreate property.
        /// </summary>
        /// <param name="sender">The button that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dto = new ContactWriteDto
            {
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                BirthDate = birthDatePicker.Value.Date,
                PhoneNumber = phoneNumberTextBox.Text.Trim(),
                IsActive = isActiveCheckBox.Checked,
                LocationId = (int)(cityComboBox.SelectedValue ?? 0)
            };

            var result = _validator.Validate(dto);

            if (!result.IsValid)
            {
                var errorMessages = string.Join("\n", result.Errors.Select(x => x.ErrorMessage));
                MessageBox.Show(errorMessages,
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            ContactToCreate = dto;
            DialogResult = DialogResult.OK;
        }
    }
}
