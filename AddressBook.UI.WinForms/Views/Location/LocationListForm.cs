using AddressBook.Application.Interfaces.Location;
using AddressBook.Application.Services;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Presenters;
using AddressBook.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.Shared.DTOs.Location;

namespace AddressBook.UI.WinForms.Views.Location
{
    public partial class LocationListForm : Form, ILocationView
    {
        private readonly LocationPresenter presenter;
        private string _lastSortedColumn = "";
        private bool _sortAscending = true;
        private readonly ILocationService _locationService;

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

        private void InitializeGridColumns()
        {
            dataGridLocations.AutoGenerateColumns = false;
            dataGridLocations.Columns.Clear();

            dataGridLocations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CityName",
                HeaderText = "City",
                Name = "CityName",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridLocations.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PostalCode",
                HeaderText = "Postal Code",
                Name = "PostalCode",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        public event EventHandler AddClicked;
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler FilterTextChanged;
        public event EventHandler SelectionChanged;

        public List<LocationReadDto> Locations
        {
            get => (List<LocationReadDto>)dataGridLocations.DataSource;
            set => dataGridLocations.DataSource = value;
        }

        public string FilterValue => filterTextBox.Text;

        public int SelectedLocationId
        {
            get
            {
                if (dataGridLocations.CurrentRow?.DataBoundItem is LocationReadDto location)
                    return location.Id;
                return -1;
            }
        }

        public void LoadLocations(List<LocationReadDto> locations)
        {
            Locations = locations;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ClearFilter()
        {
            filterTextBox.Clear();
        }
        public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick
        {
            add { dataGridLocations.ColumnHeaderMouseClick += value; }
            remove { dataGridLocations.ColumnHeaderMouseClick -= value; }
        }
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
