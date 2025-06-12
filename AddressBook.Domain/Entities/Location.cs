using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Entities
{
    /// <summary>
    /// Represents a postal location with code and name.
    /// </summary>
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
