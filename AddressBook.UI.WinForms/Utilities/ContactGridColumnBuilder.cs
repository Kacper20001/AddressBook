using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Utilities
{
    public static class ContactGridColumnBuilder
    {
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

        private static DataGridViewTextBoxColumn CreateTextColumn(string property, string header, string name, DataGridViewAutoSizeColumnMode sizeMode, string format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = property,
                HeaderText = header,
                Name = name,
                ReadOnly = true,
                AutoSizeMode = sizeMode
            };

            if (!string.IsNullOrEmpty(format))
            {
                column.DefaultCellStyle = new DataGridViewCellStyle { Format = format };
            }

            return column;
        }

        private static DataGridViewCheckBoxColumn CreateCheckBoxColumn(string property, string header, string name, DataGridViewAutoSizeColumnMode sizeMode)
        {
            return new DataGridViewCheckBoxColumn
            {
                DataPropertyName = property,
                HeaderText = header,
                Name = name,
                ReadOnly = true,
                AutoSizeMode = sizeMode
            };
        }
    }
}
