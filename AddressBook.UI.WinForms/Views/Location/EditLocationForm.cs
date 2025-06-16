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

namespace AddressBook.UI.WinForms.Views.Location
{
    public partial class EditLocationForm : Form
    {
        public LocationWriteDto UpdatedLocation { get; private set; }
        public int LocationId { get; private set; }

        public EditLocationForm()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        public void LoadLocation(LocationReadDto location)
        {
            LocationId = location.Id;
            cityNameTextBox.Text = location.CityName;
            postalCodeTextBox.Text = location.PostalCode;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string cityName = cityNameTextBox.Text.Trim();
            string postalCode = postalCodeTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(cityName) || string.IsNullOrWhiteSpace(postalCode))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            UpdatedLocation = new LocationWriteDto
            {
                CityName = cityName,
                PostalCode = postalCode
            };

            DialogResult = DialogResult.OK;
        }
    }
}

