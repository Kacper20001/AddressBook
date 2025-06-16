using AddressBook.Shared.DTOs.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Interfaces
{
    public interface ILocationView
    {
        List<LocationReadDto> Locations { get; set; }
        string FilterValue { get; }
        int SelectedLocationId { get; }

        event EventHandler AddClicked;
        event EventHandler EditClicked;
        event EventHandler DeleteClicked;
        event EventHandler SelectionChanged;
        event EventHandler FilterTextChanged;
        event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick;


        void LoadLocations(List<LocationReadDto> locations);
        void ShowMessage(string message);
        void ClearFilter();
    }
}
