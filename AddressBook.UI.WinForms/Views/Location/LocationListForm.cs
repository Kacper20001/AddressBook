using AddressBook.Application.Interfaces.Location;
using AddressBook.Application.Services;
using AddressBook.Shared.DTOs.Location;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Presenters;
using AddressBook.UI.WinForms.Utilities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views.Location
{
    /// <summary>
    /// Main form used to manage the list of locations.
    /// </summary>
    public partial class LocationListForm : Form, ILocationView
    {
        private readonly ILocationService _locationService;
        private readonly IValidator<LocationWriteDto> _validator;
        private List<LocationReadDto> _allLocations = new List<LocationReadDto>();

        /// <inheritdoc />
        public event EventHandler AddClicked;

        /// <inheritdoc />
        public event EventHandler EditClicked;

        /// <inheritdoc />
        public event EventHandler DeleteClicked;

        /// <inheritdoc />
        public event EventHandler SelectionChanged;

        /// <inheritdoc />
        public event EventHandler FilterTextChanged;

        /// <inheritdoc />
        public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;

        /// <inheritdoc />
        public event DataGridViewCellMouseEventHandler SortRequested;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationListForm"/> class.
        /// </summary>
        /// <param name="locationService">Service used to manage locations.</param>
        /// <param name="validator">Validator for location input.</param>
        public LocationListForm(ILocationService locationService, IValidator<LocationWriteDto> validator)
        {
            _locationService = locationService;
            _validator = validator;

            InitializeComponent();

            var presenter = new LocationPresenter(this, locationService, validator);

            // Configure DataGridView
            dataGridLocations.AutoGenerateColumns = false;
            dataGridLocations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridLocations.MultiSelect = false;
            dataGridLocations.ReadOnly = true;
            dataGridLocations.AllowUserToAddRows = false;
            dataGridLocations.AllowUserToDeleteRows = false;

            dataGridLocations.Columns.Clear();
            dataGridLocations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 50 });
            dataGridLocations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CityName", HeaderText = "City", Width = 150 });
            dataGridLocations.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PostalCode", HeaderText = "Postal Code", Width = 100 });

            // Hook events
            addLocationButton.Click += (s, e) => AddClicked?.Invoke(s, e);
            editLocationButton.Click += (s, e) => EditClicked?.Invoke(s, e);
            deleteLocationButton.Click += (s, e) => DeleteClicked?.Invoke(s, e);
            dataGridLocations.SelectionChanged += (s, e) => SelectionChanged?.Invoke(s, e);
            dataGridLocations.ColumnHeaderMouseClick += (s, e) => SortRequested?.Invoke(dataGridLocations, e);
            dataGridLocations.SortCompare += DataGridLocations_SortCompare;
            filterTextBox.TextChanged += (s, e) => FilterTextChanged?.Invoke(s, e);
            clearFilterButton.Click += (s, e) =>
            {
                filterTextBox.Clear();
                FilterTextChanged?.Invoke(s, e);
            };
        }

        /// <inheritdoc />
        public List<LocationReadDto> Locations
        {
            set
            {
                _allLocations = value ?? new List<LocationReadDto>();
                ApplyFilter();
            }
        }

        /// <inheritdoc />
        public int SelectedLocationId
        {
            get
            {
                if (dataGridLocations.CurrentRow?.DataBoundItem is LocationReadDto loc)
                    return loc.Id;
                return -1;
            }
        }

        /// <inheritdoc />
        public LocationWriteDto LocationToCreate => new LocationWriteDto();

        /// <inheritdoc />
        public string FilterValue => filterTextBox.Text.Trim();

        /// <inheritdoc />
        public void LoadLocations(List<LocationReadDto> locations)
        {
            _allLocations = locations ?? new List<LocationReadDto>();
            ApplyFilter();
        }

        /// <inheritdoc />
        public void ShowMessage(string message) => MessageBox.Show(message);

        /// <inheritdoc />
        public void ClearForm()
        {
            filterTextBox.Clear();
            dataGridLocations.ClearSelection();
        }

        /// <inheritdoc />
        public void ClearFilter()
        {
            filterTextBox.Clear();
            ApplyFilter();
        }

        /// <summary>
        /// Applies text-based filter to the location list.
        /// </summary>
        private void ApplyFilter()
        {
            string filter = FilterValue.ToLower();
            var filtered = string.IsNullOrEmpty(filter)
                ? _allLocations
                : _allLocations.Where(l =>
                    l.Id.ToString().Contains(filter) ||
                    (l.CityName?.ToLower().Contains(filter) ?? false) ||
                    (l.PostalCode?.ToLower().Contains(filter) ?? false)
                ).ToList();

            dataGridLocations.DataSource = filtered;
        }

        /// <summary>
        /// Handles sorting logic when columns are clicked.
        /// </summary>
        private void DataGridLocations_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = string.Compare(
                e.CellValue1?.ToString(),
                e.CellValue2?.ToString(),
                StringComparison.OrdinalIgnoreCase
            );
            e.Handled = true;
        }

        /// <summary>
        /// Opens the contact management form and hides the current form.
        /// </summary>
        private void ContactsButton_Click(object sender, EventArgs e)
        {
            FormNavigator.ShowContactForm(this);
        }
    }
}
