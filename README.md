
# AddressBook – Windows Forms Contact Management System

**AddressBook** is a  desktop application built in **C# (.NET Framework 4.8)** using **WinForms**. It allows for managing contacts and their locations, with full CRUD functionality, filtering, sorting, validation, and usage of SQL Views. The solution follows **Clean Architecture**, separates **Read/Write DTOs**, implements **MVP (Model-View-Presenter)** in the UI, and uses **EF Core Code First + Migrations** with a fully generated SQL database script.

---

##  Technologies Used

-  C# WinForms (.NET Framework 4.8)
-  Entity Framework Core (Code First + Migrations)
-  AutoMapper
-  FluentValidation
-  SQL Server LocalDB
-  Clean Architecture (Domain, Application, Infrastructure, UI)
-  MVP (Model-View-Presenter)
-  XML Documentation, Dependency Injection, SOLID principles

---

##  Project Structure

```
AddressBook/
├── AddressBook.Domain/           → EF Core entities (Contact, Location)
├── AddressBook.Application/      → Interfaces, Services, DTOs, UnitOfWork
├── AddressBook.Infrastructure/   → DbContext, Repositories, EF Configurations
├── AddressBook.UI.WinForms/      → User Interface with MVP pattern
├── AddressBook.Shared/           → Shared DTOs (Read/Write), common models
├── DatabaseScripts/              → Full SQL schema (CreateDatabase.sql)
├── AddressBook.sln               → Visual Studio solution file
```

---

##  Cloning & First-Time Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/AddressBook.git
   cd AddressBook
   ```

2. **Open the solution in Visual Studio** (recommended: 2022+).

3. **Set the following startup project:**
   - **`AddressBook.UI.WinForms`** (WinForms frontend)

---

##  Database Setup

### Option 1 – Use EF Core Migrations (Recommended for Development)

1. Make sure the **Package Manager Console** has these settings:
   - **Default Project:** `AddressBook.Infrastructure`
   - Use this command to apply all existing migrations:

     ```powershell
     Update-Database -StartupProject AddressBook.UI.WinForms
     ```

   This will:
   - Create the database in LocalDB
   - Apply schema
   - Insert 20 predefined locations
   - Insert 10 sample contacts (with `IDENTITY_INSERT`)

2. To re-generate the SQL script manually:

   ```powershell
   Script-Migration -StartupProject AddressBook.UI.WinForms -Output "DatabaseScripts/CreateDatabase.sql"
   ```

---

### Option 2 – Manual SQL Script Execution

1. Open `DatabaseScripts/CreateDatabase.sql`
2. Run it in SQL Server Management Studio (SSMS)
3. It will:
   - Create tables: `Locations`, `Contacts`
   - Seed data (locations + contacts)
   - Create `ContactView` SQL view
   - Track migrations in `__EFMigrationsHistory`

---

## Running the Application

1. **Ensure AddressBook.UI.WinForms is the startup project**
2. Press `F5` or click **Start**
3. The WinForms UI will launch and connect to LocalDB
4. Contacts will be displayed via the `ContactView` SQL View
5. Full CRUD + sorting + filtering is available out of the box

---

## Features

- Add / Edit / Delete Contacts
- Filter / Sort Contacts by any column
- Add / Edit Locations (managed in separate dialog)
- Dropdown list of locations for contacts
- SQL View (`ContactView`) combining Contacts + Locations
- MVP architecture in UI (Forms ↔ Presenters ↔ Services)
- FluentValidation for Contact + Location forms
- Manual & automatic testing, UI-friendly form layout
- Full XML documentation (summary) for all classes and interfaces

---

## Manual Testing Summary

| Feature                              | Status |
|--------------------------------------|--------|
| Contact CRUD                         | ✅     |
| Location management (Add/Edit)       | ✅     |
| Filtering & sorting in DataGridView  | ✅     |
| SQL View (`ContactView`) working     | ✅     |
| Form validation (FluentValidation)   | ✅     |
| MVP interface implementation         | ✅     |

---

## Coding Standards

-  Public classes/methods/properties: `PascalCase`
-  Private/local variables: `camelCase`
-  XML Comments `<summary>` for all methods and interfaces
-  Read/Write DTOs separated (e.g., `ContactReadDto`, `ContactWriteDto`)
-  Clean separation of concerns (no logic in UI)
-  SOLID, Clean Code, DI, AutoMapper Profiles, no code duplication

---

## Notes

- Folder `DatabaseScripts/` contains the full auto-generated DB schema.
- No code smells: all Forms are clean and rely on injected Presenters.
- FluentValidation integrated into the UI layer.
- Repositories & Unit of Work pattern used in `Application` layer.
- `IContactView`, `ILocationView` and all events handled with MVP.

---

##  Author

**Kacper Kulig**