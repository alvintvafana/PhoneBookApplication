using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PhoneBookApplication.UnitTest
{
    public class PhoneBookRepositoryMock : IPhoneBookRepository
    {
        public List<PhoneBookAggregateRoot> phoneBookAggregates = new List<PhoneBookAggregateRoot>();
        public async Task AddAsync(PhoneBookAggregateRoot wallet)
        {
           await Task.Run(()=>phoneBookAggregates.Add(wallet));   
        }

        public async Task<PhoneBookAggregateRoot> GetPhoneBookByIdAsync(Guid id)
        {
            return await Task.Run(() => phoneBookAggregates.FirstOrDefault(a => a.Id == a.Id));
        }

        public async Task<PhoneBookAggregateRoot> GetPhoneBookByNameAsync(string name)
        {
            return await Task.Run(() => phoneBookAggregates.FirstOrDefault(a => a.Name == a.Name));
        }

        public Task<IEnumerable<Entry>> SearchPhoneBookAsync(Guid id,string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PhoneBookAggregateRoot>> GetPhoneBooksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await Task.Run(()=>"saving");
        }

        public void Update(PhoneBookAggregateRoot wallet)
        {
            phoneBookAggregates.Add(wallet);
        }
    }
}
