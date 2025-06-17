using AddressBook.Shared.DTOs.Location;
using System;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views.Location
{
    /// <summary>
    /// Form for editing an existing location.
    /// </summary>
    public partial class EditLocationForm : Form
    {
        /// <summary>
        /// Gets the updated location data after confirmation.
        /// </summary>
        public LocationWriteDto UpdatedLocation { get; private set; }

        /// <summary>
        /// Gets the identifier of the edited location.
        /// </summary>
        public int LocationId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditLocationForm"/> class.
        /// </summary>
        public EditLocationForm()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Loads location data into the form fields.
        /// </summary>
        /// <param name="location">Location to be edited.</param>
        public void LoadLocation(LocationReadDto location)
        {
            LocationId = location.Id;
            cityNameTextBox.Text = location.CityName;
            postalCodeTextBox.Text = location.PostalCode;
        }

        /// <summary>
        /// Validates input and sets the updated location DTO if successful.
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

            UpdatedLocation = new LocationWriteDto
            {
                CityName = cityName,
                PostalCode = postalCode
            };

            DialogResult = DialogResult.OK;
        }
    }
}

