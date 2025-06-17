using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain.Entities
{
    /// <summary>
    /// Represents the 'Locations' entity mapped to a SQL table using Entity Framework Core.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the unique identifier of the location.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the location.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city name of the location.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the collection of contacts related to this location.
        /// </summary>
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
