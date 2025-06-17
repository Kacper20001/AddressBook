using AddressBook.Shared.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Interfaces
{
    /// <summary>
    /// Defines the interface for the location view in the MVP architecture.
    /// </summary>
    public interface ILocationView
    {
        /// <summary>
        /// Sets the list of locations to be displayed.
        /// </summary>
        List<LocationReadDto> Locations { set; }

        /// <summary>
        /// Gets the ID of the currently selected location.
        /// </summary>
        int SelectedLocationId { get; }

        /// <summary>
        /// Gets the data used to create a new location.
        /// </summary>
        LocationWriteDto LocationToCreate { get; }

        /// <summary>
        /// Gets the current text value used for filtering the location list.
        /// </summary>
        string FilterValue { get; }

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
        /// Occurs when the text in the filter box changes.
        /// </summary>
        event EventHandler FilterTextChanged;

        /// <summary>
        /// Occurs when the user clicks a column header in the grid.
        /// </summary>
        event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;

        /// <summary>
        /// Occurs when the user changes the selected location in the grid.
        /// </summary>
        event EventHandler SelectionChanged;

        /// <summary>
        /// Occurs when a sort is requested for the grid.
        /// </summary>
        event DataGridViewCellMouseEventHandler SortRequested;

        /// <summary>
        /// Loads a list of locations into the view.
        /// </summary>
        /// <param name="locations">The list of locations to load.</param>
        void LoadLocations(List<LocationReadDto> locations);

        /// <summary>
        /// Displays a message to the user.
        /// </summary>
        /// <param name="message">The message to display.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Clears all user inputs and selections in the form.
        /// </summary>
        void ClearForm();

        /// <summary>
        /// Clears the filter input and refreshes the location list.
        /// </summary>
        void ClearFilter();
    }
}

