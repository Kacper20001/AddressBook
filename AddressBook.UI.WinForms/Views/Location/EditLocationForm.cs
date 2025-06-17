using AddressBook.Shared.DTOs.Location;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views.Location
{
    /// <summary>
    /// Form for editing an existing location.
    /// </summary>
    public partial class EditLocationForm : Form
    {
        private readonly IValidator<LocationWriteDto> _validator;

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
        /// <param name="validator">Validator for validating the location data.</param>
        public EditLocationForm(IValidator<LocationWriteDto> validator)
        {
            _validator = validator;
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
        /// Handles the save button click.
        /// Validates user input and sets the UpdatedLocation property.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event arguments.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dto = new LocationWriteDto
            {
                CityName = cityNameTextBox.Text.Trim(),
                PostalCode = postalCodeTextBox.Text.Trim()
            };

            ValidationResult result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage)),
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            UpdatedLocation = dto;
            DialogResult = DialogResult.OK;
        }
    }
}

