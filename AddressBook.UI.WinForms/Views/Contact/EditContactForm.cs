using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs.Location;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views
{
    /// <summary>
    /// Form used for editing an existing contact.
    /// </summary>
    public partial class EditContactForm : Form
    {
        private readonly IValidator<ContactWriteDto> _validator;
        private int _contactId;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditContactForm"/> class.
        /// </summary>
        /// <param name="validator">FluentValidation validator for ContactWriteDto.</param>
        public EditContactForm(IValidator<ContactWriteDto> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the save button click event.
        /// Validates input and updates the contact data.
        /// </summary>
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
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage)),
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            UpdatedContact = dto;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Loads a list of locations into the city ComboBox.
        /// </summary>
        /// <param name="locations">List of LocationReadDto to populate the ComboBox.</param>
        public void LoadLocations(List<LocationReadDto> locations)
        {
            cityComboBox.DataSource = locations;
            cityComboBox.DisplayMember = "Display";
            cityComboBox.ValueMember = "Id";
        }

        /// <summary>
        /// Loads the selected contact into the form for editing.
        /// </summary>
        /// <param name="dto">The ContactReadDto containing data to load.</param>
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
        /// Gets the contact data after it has been updated.
        /// </summary>
        public ContactWriteDto UpdatedContact { get; private set; }
    }
}
