namespace AddressBook.Shared.DTOs.Location
{
    /// <summary>
    /// Data Transfer Object for creating or updating a location.
    /// </summary>
    public class LocationWriteDto
    {
        /// <summary>City name of the location.</summary>
        public string CityName { get; set; }

        /// <summary>Postal code of the location.</summary>
        public string PostalCode { get; set; }
    }
}
