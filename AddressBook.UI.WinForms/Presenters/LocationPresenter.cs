using AddressBook.Application.Interfaces.Location;
using AddressBook.Shared.DTOs.Location;
using AddressBook.UI.WinForms.Interfaces;
using AddressBook.UI.WinForms.Views.Location;
using FluentValidation;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IValidator<LocationWriteDto> _validator;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private CancellationTokenSource _filterCts;



        private string _lastSortedColumn = "";
        private bool _sortAscending = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationPresenter"/> class and subscribes to view events.
        /// </summary>
        /// <param name="view">View implementing the ILocationView interface.</param>
        /// <param name="service">Service providing location data operations.</param>
        /// <param name="validator">Validator for LocationWriteDto input.</param>
        public LocationPresenter(ILocationView view, ILocationService service, IValidator<LocationWriteDto> validator)
        {
            this.view = view;
            this.service = service;
            this._validator = validator;

            view.AddClicked += OnAddClicked;
            view.EditClicked += OnEditClicked;
            view.DeleteClicked += OnDeleteClicked;
            view.FilterTextChanged += OnFilterChanged;
            view.SortRequested += OnColumnHeaderClick;

            _=LoadLocations();
        }

        /// <summary>
        /// Loads and filters locations based on current view state.
        /// Applies sorting if a column has been previously selected.
        /// </summary>
        private async Task LoadLocations()
        {
            await _semaphore.WaitAsync();
            try
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
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Handles the Add button click event.
        /// Opens the AddLocationForm, validates and saves new location if confirmed.
        /// </summary>
        /// <param name="sender">Event sender (button).</param>
        /// <param name="e">Event arguments.</param>
        private async void OnAddClicked(object sender, EventArgs e)
        {
            var form = new AddLocationForm(_validator);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var locationToAdd = form.NewLocation;
                await service.AddAsync(locationToAdd);
                view.ShowMessage("Location added.");
                await LoadLocations();
            }
        }

        /// <summary>
        /// Handles the Edit button click event.
        /// Opens the EditLocationForm with selected data, updates location if confirmed.
        /// </summary>
        /// <param name="sender">Event sender (button).</param>
        /// <param name="e">Event arguments.</param>
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

            var form = new EditLocationForm(_validator);
            form.LoadLocation(selectedLocation);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await service.UpdateAsync(form.LocationId, form.UpdatedLocation);
                view.ShowMessage("Location updated.");
                await LoadLocations();
            }
        }

        /// <summary>
        /// Handles the Delete button click event.
        /// Confirms and deletes the selected location if approved.
        /// </summary>
        /// <param name="sender">Event sender (button).</param>
        /// <param name="e">Event arguments.</param>
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
                await LoadLocations();
            }
            catch (Exception ex)
            {
                view.ShowMessage($"Error deleting location: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles column header mouse click to apply sorting.
        /// Updates sorting direction based on previous state.
        /// </summary>
        /// <param name="sender">Event sender (DataGridView).</param>
        /// <param name="e">Event arguments with column index info.</param>
        private async void OnColumnHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
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

            await LoadLocations();
        }

        /// <summary>
        /// Handles changes in the filter textbox and reloads filtered data.
        /// </summary>
        /// <param name="sender">Event sender (TextBox).</param>
        /// <param name="e">Event arguments.</param>
        private void OnFilterChanged(object sender, EventArgs e)
        {
            _ = LoadLocations();
        }
    }

}
