namespace AddressBook.Shared.DTOs.Location
{
    /// <summary>
    /// Data Transfer Object for reading location data.
    /// </summary>
    public class LocationReadDto
    {
        /// <summary>Location identifier.</summary>
        public int Id { get; set; }

        /// <summary>Postal code of the location.</summary>
        public string PostalCode { get; set; }

        /// <summary>City name of the location.</summary>
        public string CityName { get; set; }
        
        /// <summary>Display string combining city and postal code for UI. </summary>
        public string Display => $"{CityName} ({PostalCode})";
    }
}
