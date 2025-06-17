using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Utilities
{
    /// <summary>
    /// Provides methods to build columns for displaying location data in a DataGridView.
    /// </summary>
    public static class LocationGridColumnBuilder
    {
        /// <summary>
        /// Builds and returns a list of predefined columns for displaying location records.
        /// </summary>
        /// <returns>A list of DataGridViewColumns representing ID, city name, and postal code.</returns>
        public static List<DataGridViewColumn> BuildColumns()
        {
            return new List<DataGridViewColumn>
        {
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CityName",
                HeaderText = "City",
                Width = 150
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PostalCode",
                HeaderText = "Postal Code",
                Width = 100
            }
        };
        }
    }
}
