using AddressBook.Shared.DTOs.Contact;
using AddressBook.Shared.DTOs.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views
{
    public partial class EditContactForm : Form
    {
        private int _contactId;

        public EditContactForm()
        {
            InitializeComponent();
            saveButton.Click += (s, e) => DialogResult = DialogResult.OK;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        public void LoadLocations(List<LocationReadDto> locations)
        {
            cityComboBox.DataSource = locations;
            cityComboBox.DisplayMember = "Display";
            cityComboBox.ValueMember = "Id";
        }

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

        public int ContactId => _contactId;

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
