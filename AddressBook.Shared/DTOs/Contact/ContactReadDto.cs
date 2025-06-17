using System;

namespace AddressBook.Shared.DTOs.Contact
{
    /// <summary>
    /// Data Transfer Object (DTO) for reading full contact data, including related location info.
    /// </summary>
    public class ContactReadDto
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

        /// <summary>Postal code of the contact's location.</summary>
        public string PostalCode { get; set; }

        /// <summary>Name of the city associated with the contact.</summary>
        public string CityName { get; set; }

        /// <summary>Location identifier associated with the contact.</summary>
        public int LocationId { get; set; }
    }
}
