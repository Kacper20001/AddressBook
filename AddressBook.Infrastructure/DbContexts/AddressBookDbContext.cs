using AddressBook.Domain.Entities;
using AddressBook.Shared.DTOs.Contact;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.DbContexts
{
    /// <summary>
    /// Main EF Core DbContext for the address book.
    /// </summary>
    public class AddressBookDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookDbContext"/> class.
        /// </summary>
        /// <param name="options">Options used by DbContext.</param>
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the table for contacts.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets the table for locations.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the view for displaying combined contact data.
        /// </summary>
        public DbSet<ContactViewResultDto> ContactView { get; set; }

        /// <summary>
        /// Configures entity relationships and views.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Location)
                .WithMany(l => l.Contacts)
                .HasForeignKey(c => c.LocationId);

            modelBuilder.Entity<ContactViewResultDto>()
                .HasNoKey()
                .ToView("ContactView");

            base.OnModelCreating(modelBuilder);
        }
    }
}
