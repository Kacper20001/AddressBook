using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Infrastructure.Migrations
{
    public partial class CreateContactView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW ContactView AS
        SELECT 
            c.Id,
            c.FirstName,
            c.LastName,
            c.BirthDate,
            c.PhoneNumber,
            c.IsActive,
            l.PostalCode,
            l.CityName
        FROM Contacts c
        JOIN Locations l ON c.LocationId = l.Id;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS ContactView;");
        }
    }
}
