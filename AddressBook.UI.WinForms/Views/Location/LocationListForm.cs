using AddressBook.Application.Interfaces.Location;
using AddressBook.Shared.DTOs.Location;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Presenters;
using AddressBook.UI.WinForms.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Views.Location
{
    /// <summary>
    /// Represents the form used to display and manage the list of locations.
    /// </summary>
    public partial class LocationListForm : Form, ILocationView
    {
        private readonly LocationPresenter presenter;
        private string _lastSortedColumn = "";
        private bool _sortAscending = true;
        private readonly ILocationService _locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationListForm"/> class.
        /// </summary>
        /// <param name="locationService">Service used to handle location data.</param>
        public LocationListForm(ILocationService locationService)
        {
            InitializeComponent();
            presenter = new LocationPresenter(this, locationService);

            InitializeGridColumns();

            addLocationButton.Click += (s, e) => AddClicked?.Invoke(s, e);
            editLocationButton.Click += (s, e) => EditClicked?.Invoke(s, e);
            deleteLocationButton.Click += (s, e) => DeleteClicked?.Invoke(s, e);
            filterTextBox.TextChanged += (s, e) => ApplyFilterAndSort();
            dataGridLocations.SelectionChanged += (s, e) => SelectionChanged?.Invoke(s, e);
            dataGridLocations.ColumnHeaderMouseClick += OnColumnHeaderClick;
            ApplyFilterAndSort();
        }

        /// <summary>
        /// Initializes the columns of the location DataGridView.
        /// </summary>
        private void InitializeGridColumns()
        {
            dataGridLocations.AutoGenerateColumns = false;
            dataGridLocations.Columns.Clear();

            var columns = LocationGridColumnBuilder.BuildColumns();
            dataGridLocations.Columns.AddRange(columns.ToArray());
        }

        /// <summary>
        /// Occurs when the Add button is clicked.
        /// </summary>
        public event EventHandler AddClicked;

        /// <summary>
        /// Occurs when the Edit button is clicked.
        /// </summary>
        public event EventHandler EditClicked;

        /// <summary>
        /// Occurs when the Delete button is clicked.
        /// </summary>
        public event EventHandler DeleteClicked;

        /// <summary>
        /// Occurs when the text in the filter box is changed.
        /// </summary>
        public event EventHandler FilterTextChanged;

        /// <summary>
        /// Occurs when the selected row in the grid is changed.
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Gets or sets the list of locations to be displayed in the grid.
        /// </summary>
        public List<LocationReadDto> Locations
        {
            get => (List<LocationReadDto>)dataGridLocations.DataSource;
            set => dataGridLocations.DataSource = value;
        }

        /// <summary>
        /// Gets the current filter text entered by the user.
        /// </summary>
        public string FilterValue => filterTextBox.Text;

        /// <summary>
        /// Gets the ID of the currently selected location.
        /// </summary>
        public int SelectedLocationId
        {
            get
            {
                if (dataGridLocations.CurrentRow?.DataBoundItem is LocationReadDto location)
                    return location.Id;
                return -1;
            }
        }

        /// <summary>
        /// Loads a list of locations into the grid.
        /// </summary>
        /// <param name="locations">List of locations to display.</param>
        public void LoadLocations(List<LocationReadDto> locations)
        {
            Locations = locations;
        }

        /// <summary>
        /// Displays a message box with the specified message.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Clears the filter input field.
        /// </summary>
        public void ClearFilter()
        {
            filterTextBox.Clear();
        }

        /// <summary>
        /// Occurs when a column header is clicked.
        /// </summary>
        public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick
        {
            add { dataGridLocations.ColumnHeaderMouseClick += value; }
            remove { dataGridLocations.ColumnHeaderMouseClick -= value; }
        }

        /// <summary>
        /// Handles column header clicks to perform sorting.
        /// </summary>
        private void OnColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            var columnName = grid.Columns[e.ColumnIndex].DataPropertyName;

            if (string.IsNullOrWhiteSpace(columnName)) return;

            if (_lastSortedColumn == columnName)
                _sortAscending = !_sortAscending;
            else
            {
                _lastSortedColumn = columnName;
                _sortAscending = true;
            }

            ApplyFilterAndSort();
        }

        /// <summary>
        /// Applies the current filter and sort settings to the location list.
        /// </summary>
        private void ApplyFilterAndSort()
        {
            if (Locations == null) return;

            string filter = FilterValue?.Trim().ToLower() ?? "";

            var filtered = Locations
                .Where(l =>
                    (!string.IsNullOrEmpty(l.CityName) && l.CityName.ToLower().Contains(filter)) ||
                    (!string.IsNullOrEmpty(l.PostalCode) && l.PostalCode.ToLower().Contains(filter))
                )
                .ToList();

            if (!string.IsNullOrEmpty(_lastSortedColumn))
            {
                filtered = _sortAscending
                    ? filtered.OrderBy(l => l.GetType().GetProperty(_lastSortedColumn)?.GetValue(l)).ToList()
                    : filtered.OrderByDescending(l => l.GetType().GetProperty(_lastSortedColumn)?.GetValue(l)).ToList();
            }

            Locations = filtered;
        }
    }
}
