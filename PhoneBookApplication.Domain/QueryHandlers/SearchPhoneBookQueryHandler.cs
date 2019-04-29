using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Queries;
using PhoneBookApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Domain.QueryHandlers
{
    public class SearchPhoneBookQueryHandler : IQueryHandler<SearchPhoneBookQuery, IEnumerable<Entry>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        public SearchPhoneBookQueryHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<IEnumerable<Entry>> HandleAsync(SearchPhoneBookQuery query)
        {
            return await _phoneBookRepository.SearchPhoneBookAsync(query.PhoneBookId,query.Name);
        }
    }
}
