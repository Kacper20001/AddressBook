IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Locations] (
    [Id] int NOT NULL IDENTITY,
    [PostalCode] nvarchar(10) NOT NULL,
    [CityName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [BirthDate] date NOT NULL,
    [PhoneNumber] nvarchar(20) NOT NULL,
    [IsActive] bit NOT NULL,
    [LocationId] int NOT NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_Locations_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Locations] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Contacts_LocationId] ON [Contacts] ([LocationId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250612170230_InitialCreate', N'3.1.32');

GO


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
    

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250612200025_SeedLocationsManually', N'3.1.32');

GO


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
    

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250612200946_CreateContactView', N'3.1.32');

GO


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
    

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250617174309_SeedContactsManually', N'3.1.32');

GO

