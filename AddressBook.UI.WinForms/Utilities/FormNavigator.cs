using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook.UI.WinForms.Utilities
{
    /// <summary>
    /// Provides navigation methods between forms in the AddressBook application.
    /// </summary>
    public static class FormNavigator
    {
        /// <summary>
        /// Gets or sets the factory method for creating the contact form.
        /// </summary>
        public static Func<Form> ContactFormFactory { get; set; }

        /// <summary>
        /// Gets or sets the factory method for creating the location form.
        /// </summary>
        public static Func<Form> LocationFormFactory { get; set; }

        /// <summary>
        /// Opens the location form modally and returns to the current form afterwards.
        /// </summary>
        /// <param name="current">The currently active form that should be hidden during navigation.</param>
        public static void ShowLocationForm(Form current)
        {
            current.Hide();
            using (var form = LocationFormFactory())
            {
                form.ShowDialog();
            }
            current.Show();
        }

        /// <summary>
        /// Opens the contact form modally and returns to the current form afterwards.
        /// </summary>
        /// <param name="current">The currently active form that should be hidden during navigation.</param>
        public static void ShowContactForm(Form current)
        {
            current.Hide();
            using (var form = ContactFormFactory())
            {
                form.ShowDialog();
            }
            current.Show();
        }
    }
}
