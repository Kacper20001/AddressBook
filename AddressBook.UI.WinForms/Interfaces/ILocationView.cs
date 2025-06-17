using AddressBook.Shared.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Interfaces
{
    /// <summary>
    /// Interface for the location view in the MVP pattern.
    /// </summary>
    public interface ILocationView
    {
        /// <summary>
        /// Gets or sets the list of displayed locations.
        /// </summary>
        List<LocationReadDto> Locations { get; set; }

        /// <summary>
        /// Gets the value used for filtering locations.
        /// </summary>
        string FilterValue { get; }

        /// <summary>
        /// Gets the ID of the currently selected location.
        /// </summary>
        int SelectedLocationId { get; }

        /// <summary>
        /// Occurs when the Add button is clicked.
        /// </summary>
        event EventHandler AddClicked;

        /// <summary>
        /// Occurs when the Edit button is clicked.
        /// </summary>
        event EventHandler EditClicked;

        /// <summary>
        /// Occurs when the Delete button is clicked.
        /// </summary>
        event EventHandler DeleteClicked;

        /// <summary>
        /// Occurs when the selection changes in the data grid.
        /// </summary>
        event EventHandler SelectionChanged;

        /// <summary>
        /// Occurs when the filter text value is changed.
        /// </summary>
        event EventHandler FilterTextChanged;

        /// <summary>
        /// Occurs when a column header is clicked in the data grid (for sorting).
        /// </summary>
        event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;

        /// <summary>
        /// Loads the provided list of locations into the view.
        /// </summary>
        /// <param name="locations">The list of locations to load.</param>
        void LoadLocations(List<LocationReadDto> locations);

        /// <summary>
        /// Displays a message to the user.
        /// </summary>
        /// <param name="message">Message text to display.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Clears the current value of the location filter.
        /// </summary>
        void ClearFilter();
    }
}
