using PhoneBookApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Domain.Services
{
    public interface IPhoneBookRepository
    {
        Task<IEnumerable<PhoneBookAggregateRoot>> GetPhoneBooksAsync();
        Task<PhoneBookAggregateRoot> GetPhoneBookByNameAsync(string name);
        Task<PhoneBookAggregateRoot> GetPhoneBookByIdAsync(Guid id);
        Task<IEnumerable<Entry>> SearchPhoneBookAsync(Guid id, string name);

        Task SaveAsync();
        Task AddAsync(PhoneBookAggregateRoot wallet);
        void Update(PhoneBookAggregateRoot wallet);
    }
}
