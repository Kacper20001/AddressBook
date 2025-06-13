using AddressBook.Infrastructure.DbContexts;
using AddressBook.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure
{
    public class UnitOfWork : IUn
    {
        private readonly AddressBookDbContext context;

        public IContactRepository Contacts { get; }

        public UnitOfWork(AddressBookDbContext context)
        {
            this.context = context;
            Contacts = new ContactRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
