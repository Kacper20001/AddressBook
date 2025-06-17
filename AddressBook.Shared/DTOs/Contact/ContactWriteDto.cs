using System;

namespace AddressBook.Shared.DTOs.Contact
{
    /// <summary>
    /// DTO for creating or updating contact data.
    /// </summary>
    public class ContactWriteDto
    {
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

        /// <summary>ID of the related location.</summary>
        public int LocationId { get; set; }
    }
}
