using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Infrastructure.Migrations
{
    public partial class SeedContactsManually : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        SET IDENTITY_INSERT Contacts ON;

        INSERT INTO Contacts (Id, FirstName, LastName, PhoneNumber, BirthDate, IsActive, LocationId)
        VALUES
        (1, 'Jan', 'Kowalski', '500100200', '1990-01-01', 1, 10),
        (2, 'Anna', 'Nowak', '511222333', '1985-05-12', 1, 8),
        (3, 'Piotr', 'Wiśniewski', '522333444', '1992-07-23', 1, 3),
        (4, 'Katarzyna', 'Wójcik', '533444555', '1988-03-04', 0, 1),
        (5, 'Tomasz', 'Kaczmarek', '544555666', '1991-09-14', 1, 2),
        (6, 'Agnieszka', 'Mazur', '555666777', '1980-12-31', 1, 3),
        (7, 'Marek', 'Krawczyk', '566777888', '1995-06-18', 0, 6),
        (8, 'Ewa', 'Piotrowska', '577888999', '1993-10-10', 1, 2),
        (9, 'Rafał', 'Grabowski', '588999000', '1987-02-22', 1, 3),
        (10, 'Zofia', 'Pawlak', '599000111', '1990-11-11', 1, 5);

        SET IDENTITY_INSERT Contacts OFF;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Contacts WHERE Id BETWEEN 1 AND 10");
        }
    }
}
