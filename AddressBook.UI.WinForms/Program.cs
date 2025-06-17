using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using AddressBook.Infrastructure.DbContexts;
using AddressBook.Shared.Mappings;
using AddressBook.Shared.Validation;
using AddressBook.Shared.DTOs.Contact;
using FluentValidation;
using AddressBook.Application.Interfaces;
using AddressBook.Application.Services;
using AddressBook.Infrastructure;
using AddressBook.Application.Interfaces.Location;
using WinFormsApp = System.Windows.Forms.Application;
using AddressBook.UI.WinForms.Presenters;
using AddressBook.Infrastructure.Repositories;
using AddressBook.Application.Interfaces.ReadModels;
using AddressBook.Shared.DTOs.Location;
using AddressBook.UI.WinForms.Utilities;
using AddressBook.UI.WinForms.Views.Location;

namespace AddressBook.UI.WinForms
{
    /// <summary>
    /// The main entry point for the AddressBook WinForms application.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Configures services, sets up dependency injection and starts the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // Configure EF Core with SQL Server
            services.AddDbContext<AddressBookDbContext>(options =>
                options.UseSqlServer(
                    System.Configuration.ConfigurationManager
                        .ConnectionStrings["AddressBookDb"]
                        .ConnectionString));

            // Register AutoMapper profiles
            services.AddAutoMapper(typeof(ContactProfile).Assembly);

            // Register FluentValidation validators
            services.AddTransient<IValidator<ContactWriteDto>, ContactWriteDtoValidator>();
            services.AddTransient<IValidator<LocationWriteDto>, LocationWriteDtoValidator>();

            // Register domain services and repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IContactViewRepository, ContactViewRepository>();

            // Register ContactListForm using a factory for constructor injection
            services.AddScoped<ContactListForm>(provider =>
            {
                var contactService = provider.GetRequiredService<IContactService>();
                var locationService = provider.GetRequiredService<ILocationService>();
                var locationValidator = provider.GetRequiredService<IValidator<LocationWriteDto>>();
                var contactValidator = provider.GetRequiredService<IValidator<ContactWriteDto>>();

                return new ContactListForm(contactService, locationService, locationValidator, contactValidator);
            });

            // Build the service provider for DI
            var serviceProvider = services.BuildServiceProvider();

            // Configure global form factories for navigation
            FormNavigator.ContactFormFactory = () => serviceProvider.GetRequiredService<ContactListForm>();
            FormNavigator.LocationFormFactory = () => new LocationListForm(
                serviceProvider.GetRequiredService<ILocationService>(),
                serviceProvider.GetRequiredService<IValidator<LocationWriteDto>>());

            // Standard WinForms application startup
            WinFormsApp.EnableVisualStyles();
            WinFormsApp.SetCompatibleTextRenderingDefault(false);

            try
            {
                var mainForm = serviceProvider.GetRequiredService<ContactListForm>();
                var contactService = serviceProvider.GetRequiredService<IContactService>();
                var locationService = serviceProvider.GetRequiredService<ILocationService>();
                var validator = serviceProvider.GetRequiredService<IValidator<ContactWriteDto>>();

                // Attach presenter to main form
                var presenter = new ContactPresenter(mainForm, contactService, locationService, validator);

                WinFormsApp.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
