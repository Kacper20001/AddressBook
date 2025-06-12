using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Infrastructure.Migrations
{
    public partial class SeedLocationsManually : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        INSERT INTO Locations (PostalCode, CityName) VALUES
        ('00-001', 'Warszawa'),
        ('30-002', 'Kraków'),
        ('50-003', 'Wrocław'),
        ('80-004', 'Gdańsk'),
        ('60-005', 'Poznań'),
        ('90-006', 'Łódź'),
        ('70-007', 'Szczecin'),
        ('85-008', 'Bydgoszcz'),
        ('20-009', 'Lublin'),
        ('40-010', 'Katowice'),
        ('15-011', 'Białystok'),
        ('81-012', 'Gdynia'),
        ('42-013', 'Częstochowa'),
        ('26-014', 'Radom'),
        ('87-015', 'Toruń'),
        ('25-016', 'Kielce'),
        ('35-017', 'Rzeszów'),
        ('44-018', 'Gliwice'),
        ('41-019', 'Zabrze'),
        ('10-020', 'Olsztyn');
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        DELETE FROM Locations WHERE PostalCode IN (
        '00-001', '30-002', '50-003', '80-004', '60-005',
        '90-006', '70-007', '85-008', '20-009', '40-010',
        '15-011', '81-012', '42-013', '26-014', '87-015',
        '25-016', '35-017', '44-018', '41-019', '10-020');
    ");
        }
    }
}
