using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Entities
{
    /// <summary>
    /// Represents the 'Contacts' entity mapped to a SQL table using Entity Framework Core.
    /// </summary>
    [Table("Contacts")]
    public class Contact
    {
        /// <summary>
        /// Gets or sets the unique identifier of the contact.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the contact.
        /// </summary>
        [Required]
        [Column("BirthDate", TypeName = "date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the contact's phone number.
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the contact is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the location entity.
        /// </summary>
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location associated with this contact.
        /// </summary>
        public Location Location { get; set; }
    }
}
