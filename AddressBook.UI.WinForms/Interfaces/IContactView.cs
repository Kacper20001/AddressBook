using AddressBook.Shared.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.UI.WinForms.Interfaces
{
    public interface IContactView
    {
        List<ContactReadDto> Contacts { set; }
        ContactWriteDto ContactToCreate { get; }
        int SelectedContactId { get; }

        void ShowMessage(string message);
        void ClearForm();

        event EventHandler CreateClicked;
        event EventHandler UpdateClicked;
        event EventHandler DeleteClicked;
        event EventHandler SelectionChanged;
    }
}
