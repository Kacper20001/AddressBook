using AddressBook.Application.Interfaces.Location;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Views.Location;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Presenters
{
    /// <summary>
    /// Presenter handling logic for the location management view (MVP).
    /// Includes filtering, sorting and CRUD interactions.
    /// </summary>
    public class LocationPresenter
    {
        private readonly ILocationView view;
        private readonly ILocationService service;
        private string _lastSortedColumn = "";
        private bool _sortAscending = true;

        /// <summary>
        /// Initializes a new instance of the LocationPresenter class and subscribes to view events.
        /// </summary>
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

        /// <summary>
        /// Loads and filters locations based on current view state.
        /// Applies sorting if applicable.
        /// </summary>
        private async void LoadLocations()
        {
            var allLocations = await service.GetAllAsync();

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

        /// <summary>
        /// Handles the Add button click, opens form and persists new location.
        /// </summary>
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

        /// <summary>
        /// Handles the Edit button click, loads selected location and updates it after form submission.
        /// </summary>
        private async void OnEditClicked(object sender, EventArgs e)
        {
            var selectedId = view.SelectedLocationId;
            if (selectedId == -1)
            {
                view.ShowMessage("No location selected.");
                return;
            }

            var locations = await service.GetAllAsync();
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

        /// <summary>
        /// Handles the Delete button click and removes the selected location after confirmation.
        /// </summary>
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

        /// <summary>
        /// Handles column header clicks in the data grid to apply sorting.
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

            LoadLocations();
        }

        /// <summary>
        /// Handles changes in the filter text input.
        /// </summary>
        private void OnFilterChanged(object sender, EventArgs e) => LoadLocations();
    }

}
