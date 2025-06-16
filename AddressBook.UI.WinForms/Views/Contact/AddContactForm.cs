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
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        public ContactWriteDto ContactToCreate => new ContactWriteDto
        {
            FirstName = firstNameTextBox.Text.Trim(),
            LastName = lastNameTextBox.Text.Trim(),
            BirthDate = birthDatePicker.Value.Date,
            PhoneNumber = phoneNumberTextBox.Text.Trim(),
            IsActive = isActiveCheckBox.Checked,
            LocationId = (int)(cityComboBox.SelectedValue ?? 0)
        };

        public void LoadLocations(List<LocationReadDto> locations)
        {
            cityComboBox.DataSource = locations;
            cityComboBox.DisplayMember = "Display";
            cityComboBox.ValueMember = "Id";
        }
    }
}
