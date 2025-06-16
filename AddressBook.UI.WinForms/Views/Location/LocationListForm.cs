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

        public LocationListForm(ILocationService locationService)
        {
            InitializeComponent();
            presenter = new LocationPresenter(this, locationService);

            InitializeGridColumns();

            addLocationButton.Click += (s, e) => AddClicked?.Invoke(s, e);
            editLocationButton.Click += (s, e) => EditClicked?.Invoke(s, e);
            deleteLocationButton.Click += (s, e) => DeleteClicked?.Invoke(s, e);
            filterTextBox.TextChanged += (s, e) => FilterTextChanged?.Invoke(s, e);
            dataGridLocations.SelectionChanged += (s, e) => SelectionChanged?.Invoke(s, e);
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

    }
}
