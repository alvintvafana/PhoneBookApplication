using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Queries;
using PhoneBookApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Domain.QueryHandlers
{
    public class GetGetPhoneBooksQueryHandler : IQueryHandler<GetPhoneBooksQuery, IEnumerable<PhoneBookAggregateRoot>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        public GetGetPhoneBooksQueryHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<IEnumerable<PhoneBookAggregateRoot>> HandleAsync(GetPhoneBooksQuery query)
        {
            return await _phoneBookRepository.GetPhoneBooksAsync();
        }
    }
}
