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

namespace AddressBook.UI.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddDbContext<AddressBookDbContext>(options =>
                options.UseSqlServer(
                    System.Configuration.ConfigurationManager
                        .ConnectionStrings["AddressBookDb"]
                        .ConnectionString));
            services.AddAutoMapper(typeof(ContactProfile).Assembly);

            services.AddTransient<IValidator<ContactWriteDto>, ContactWriteDtoValidator>();
            services.AddTransient<IValidator<LocationWriteDto>, LocationWriteDtoValidator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ContactListForm>();
            services.AddScoped<IContactViewRepository, ContactViewRepository>();


            var serviceProvider = services.BuildServiceProvider();

            WinFormsApp.EnableVisualStyles();
            WinFormsApp.SetCompatibleTextRenderingDefault(false);

            try
            {
                var mainForm = serviceProvider.GetRequiredService<ContactListForm>();

                var contactService = serviceProvider.GetRequiredService<IContactService>();
                var locationService = serviceProvider.GetRequiredService<ILocationService>();

                var presenter = new ContactPresenter(mainForm, contactService, locationService);
                WinFormsApp.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
