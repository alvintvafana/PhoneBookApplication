using Microsoft.EntityFrameworkCore;
using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Data
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookContext _phoneBookContext;
        public PhoneBookRepository(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }
        public async Task AddAsync(PhoneBookAggregateRoot phoneBook)
        {
            await _phoneBookContext.AddAsync(phoneBook);
        }

        public async Task<PhoneBookAggregateRoot> GetPhoneBookByIdAsync(Guid id)
        {
            return await _phoneBookContext.PhoneBooks.Include(a => a.Entries).Where(a => a.Id==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entry>> SearchPhoneBookAsync(Guid id,string name)
        {
            var phoneBook = await _phoneBookContext.PhoneBooks.Where(a => a.Id == id).Include(b => b.Entries).FirstOrDefaultAsync();
            if (phoneBook == null)
                return null;
            var entries = phoneBook.Entries.Where(a => a.Name.ToLower().Contains(name.ToLower())).ToList(); 
             
            return entries;
        }

        public async Task<PhoneBookAggregateRoot> GetPhoneBookByNameAsync(string name)
        {
            return await _phoneBookContext.PhoneBooks.Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PhoneBookAggregateRoot>> GetPhoneBooksAsync()
        {
            return await _phoneBookContext.PhoneBooks.Include(a=>a.Entries).ToListAsync();
        }

        public async Task SaveAsync()
        {
           await _phoneBookContext.SaveChangesAsync();
        }

        public void Update(PhoneBookAggregateRoot phoneBook)
        {
            _phoneBookContext.Update(phoneBook);
        }

    }
}
