using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Utilities
{
    public static class LocationGridColumnBuilder
    {
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
