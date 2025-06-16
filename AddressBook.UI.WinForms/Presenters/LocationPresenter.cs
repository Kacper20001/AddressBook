using AddressBook.Application.Interfaces.Location;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Views.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Presenters
{
    public class LocationPresenter
    {
        private readonly ILocationView view;
        private readonly ILocationService service;
        private string _lastSortedColumn = "";
        private bool _sortAscending = true;

        public LocationPresenter(ILocationView view, ILocationService service)
        {
            this.view = view;
            this.service = service;

            view.AddClicked += OnAddClicked;
            view.EditClicked += OnEditClicked;
            view.DeleteClicked += OnDeleteClicked;
            view.FilterTextChanged += OnFilterChanged;

            LoadLocations();
        }

        private async void LoadLocations()
        {
            var allLocations = await service.GetAllLocations();

            var filtered = string.IsNullOrWhiteSpace(view.FilterValue)
                ? allLocations
                : allLocations.Where(l =>
                    l.CityName != null && l.CityName.IndexOf(view.FilterValue, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    l.PostalCode != null && l.PostalCode.IndexOf(view.FilterValue, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

            if (!string.IsNullOrEmpty(_lastSortedColumn))
            {
                filtered = _sortAscending
                    ? filtered.OrderBy(l => l.GetType().GetProperty(_lastSortedColumn)?.GetValue(l)).ToList()
                    : filtered.OrderByDescending(l => l.GetType().GetProperty(_lastSortedColumn)?.GetValue(l)).ToList();
            }

            view.LoadLocations(filtered);
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            var form = new AddLocationForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var locationToAdd = form.NewLocation;
                await service.AddAsync(locationToAdd); 
                view.ShowMessage("Location added.");
                LoadLocations();
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var selectedId = view.SelectedLocationId;
            if (selectedId == -1)
            {
                view.ShowMessage("No location selected.");
                return;
            }

            var locations = await service.GetAllLocations();
            var selectedLocation = locations.FirstOrDefault(l => l.Id == selectedId);
            if (selectedLocation == null)
            {
                view.ShowMessage("Selected location not found.");
                return;
            }

            var form = new EditLocationForm();
            form.LoadLocation(selectedLocation);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await service.UpdateAsync(form.LocationId, form.UpdatedLocation);
                view.ShowMessage("Location updated.");
                LoadLocations();
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (view.SelectedLocationId <= 0)
            {
                view.ShowMessage("Please select a location to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this location?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await service.DeleteAsync(view.SelectedLocationId);
                view.ShowMessage("Location deleted.");
                LoadLocations(); 
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Error deleting location: {ex.Message}");
            }
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

            LoadLocations();
        }

        private void OnFilterChanged(object sender, EventArgs e) => LoadLocations();
    }
}
