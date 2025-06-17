using System;

namespace AddressBook.Shared.DTOs.Contact
{
    /// <summary>
    /// DTO for reading contact data from the SQL view 'ContactView'.
    /// </summary>
    public class ContactViewResultDto
    {
        /// <summary>Unique identifier of the contact.</summary>
        public int Id { get; set; }

        /// <summary>First name of the contact.</summary>
        public string FirstName { get; set; }

        /// <summary>Last name of the contact.</summary>
        public string LastName { get; set; }

        /// <summary>Birth date of the contact.</summary>
        public DateTime BirthDate { get; set; }

        /// <summary>Phone number of the contact.</summary>
        public string PhoneNumber { get; set; }

        /// <summary>Indicates whether the contact is active.</summary>
        public bool IsActive { get; set; }

        /// <summary>Postal code from the associated location.</summary>
        public string PostalCode { get; set; }

        /// <summary>City name from the associated location.</summary>
        public string CityName { get; set; }
    }
}
