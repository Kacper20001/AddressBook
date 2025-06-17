using AddressBook.Shared.DTOs.Contact;
using System;
using System.Collections.Generic;

namespace AddressBook.UI.WinForms.Interfaces
{
    /// <summary>
    /// Interface for the contact view in the MVP pattern.
    /// </summary>
    public interface IContactView
    {
        /// <summary>
        /// Gets or sets the list of contacts to be displayed.
        /// </summary>
        List<ContactReadDto> Contacts { set; }

        /// <summary>
        /// Gets the contact data to create or update.
        /// </summary>
        ContactWriteDto ContactToCreate { get; }

        /// <summary>
        /// Gets the ID of the currently selected contact.
        /// </summary>
        int SelectedContactId { get; }

        /// <summary>
        /// Displays a message to the user (e.g., success or error).
        /// </summary>
        /// <param name="message">Message text to display.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Clears all input fields in the form.
        /// </summary>
        void ClearForm();

        /// <summary>
        /// Triggered when the Create button is clicked.
        /// </summary>
        event EventHandler CreateClicked;

        /// <summary>
        /// Triggered when the Update button is clicked.
        /// </summary>
        event EventHandler UpdateClicked;

        /// <summary>
        /// Triggered when the Delete button is clicked.
        /// </summary>
        event EventHandler DeleteClicked;

        /// <summary>
        /// Triggered when the selected contact changes.
        /// </summary>
        event EventHandler SelectionChanged;
    }
}
