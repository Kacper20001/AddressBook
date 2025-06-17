using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Utilities
{
    /// <summary>
    /// Provides configuration methods to build and assign columns
    /// for displaying contact data in a DataGridView.
    /// </summary>
    public static class ContactGridColumnBuilder
    {
        /// <summary>
        /// Configures the specified DataGridView with predefined columns for displaying contacts.
        /// </summary>
        /// <param name="grid">The DataGridView control to configure.</param>
        public static void Configure(DataGridView grid)
        {
            grid.Columns.Clear();

            grid.Columns.Add(CreateTextColumn("FirstName", "First Name", "colFirstName", DataGridViewAutoSizeColumnMode.Fill));
            grid.Columns.Add(CreateTextColumn("LastName", "Last Name", "colLastName", DataGridViewAutoSizeColumnMode.Fill));
            grid.Columns.Add(CreateTextColumn("BirthDate", "Birth Date", "colBirthDate", DataGridViewAutoSizeColumnMode.AllCells, "yyyy-MM-dd"));
            grid.Columns.Add(CreateTextColumn("PhoneNumber", "Phone", "colPhone", DataGridViewAutoSizeColumnMode.AllCells));
            grid.Columns.Add(CreateTextColumn("PostalCode", "Postal Code", "colPostalCode", DataGridViewAutoSizeColumnMode.AllCells));
            grid.Columns.Add(CreateTextColumn("CityName", "City", "colCity", DataGridViewAutoSizeColumnMode.Fill));
            grid.Columns.Add(CreateCheckBoxColumn("IsActive", "Active", "colIsActive", DataGridViewAutoSizeColumnMode.AllCells));
        }

        /// <summary>
        /// Creates a read-only text column with optional formatting for the DataGridView.
        /// </summary>
        /// <param name="property">The name of the data-bound property.</param>
        /// <param name="header">The column header text.</param>
        /// <param name="name">The internal column name.</param>
        /// <param name="sizeMode">Autosizing behavior for the column.</param>
        /// <param name="format">Optional display format (e.g., date or numeric format).</param>
        /// <returns>Configured DataGridViewTextBoxColumn.</returns>
        private static DataGridViewTextBoxColumn CreateTextColumn(string property, string header, string name, DataGridViewAutoSizeColumnMode sizeMode, string format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = property,
                HeaderText = header,
                Name = name,
                ReadOnly = true,
                AutoSizeMode = sizeMode,
                SortMode = DataGridViewColumnSortMode.Programmatic
            };

            if (!string.IsNullOrEmpty(format))
            {
                column.DefaultCellStyle = new DataGridViewCellStyle { Format = format };
            }

            return column;
        }

        /// <summary>
        /// Creates a read-only checkbox column for boolean properties in the DataGridView.
        /// </summary>
        /// <param name="property">The name of the data-bound property.</param>
        /// <param name="header">The column header text.</param>
        /// <param name="name">The internal column name.</param>
        /// <param name="sizeMode">Autosizing behavior for the column.</param>
        /// <returns>Configured DataGridViewCheckBoxColumn.</returns>
        private static DataGridViewCheckBoxColumn CreateCheckBoxColumn(string property, string header, string name, DataGridViewAutoSizeColumnMode sizeMode)
        {
            return new DataGridViewCheckBoxColumn
            {
                DataPropertyName = property,
                HeaderText = header,
                Name = name,
                ReadOnly = true,
                AutoSizeMode = sizeMode,
                SortMode = DataGridViewColumnSortMode.Programmatic
            };
        }
    }
}
