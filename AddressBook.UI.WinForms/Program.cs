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

            var serviceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
