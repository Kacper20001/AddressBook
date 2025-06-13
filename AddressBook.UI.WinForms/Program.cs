using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressBook.Infrastructure.DbContexts;
using AddressBook.Shared.Mappings;
using AddressBook.Shared.Validation;
using AddressBook.Shared.DTOs.Contact;
using FluentValidation;
using AddressBook.Application.Interfaces;
using AddressBook.Application.Services;
using AddressBook.Infrastructure;

namespace AddressBook.UI.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactService, ContactService>();

            var serviceProvider = services.BuildServiceProvider();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }
    }
}
