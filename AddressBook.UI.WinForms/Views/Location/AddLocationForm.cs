using AddressBook.Shared.DTOs.Location;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views.Location
{
    /// <summary>
    /// Form for adding a new location entry.
    /// </summary>
    public partial class AddLocationForm : Form
    {
        private readonly IValidator<LocationWriteDto> _validator;

        /// <summary>
        /// Gets the newly created location data after confirmation.
        /// </summary>
        public LocationWriteDto NewLocation { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddLocationForm"/> class.
        /// </summary>
        /// <param name="validator">Validator for validating the location data.</param>
        public AddLocationForm(IValidator<LocationWriteDto> validator)
        {
            _validator = validator;
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Handles the save button click.
        /// Validates user input and assigns the NewLocation property.
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

            NewLocation = dto;
            DialogResult = DialogResult.OK;
        }
    }
}
