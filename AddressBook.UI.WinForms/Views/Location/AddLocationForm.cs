using AddressBook.Shared.DTOs.Location;
using System;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views.Location
{
    /// <summary>
    /// Form for adding a new location entry.
    /// </summary>
    public partial class AddLocationForm : Form
    {
        /// <summary>
        /// Gets the newly created location data after confirmation.
        /// </summary>
        public LocationWriteDto NewLocation { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddLocationForm"/> class.
        /// </summary>
        public AddLocationForm()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Validates input and creates the new location DTO if successful.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string cityName = cityNameTextBox.Text.Trim();
            string postalCode = postalCodeTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(cityName) || string.IsNullOrWhiteSpace(postalCode))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            NewLocation = new LocationWriteDto
            {
                CityName = cityName,
                PostalCode = postalCode
            };

            DialogResult = DialogResult.OK;
        }
    }
}
