using PhoneBookApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Domain.Queries
{
   public class SearchPhoneBookQuery : IQuery<IEnumerable<Entry>>
    {
        public Guid PhoneBookId { get; set; }
        public string Name { get; set; }
    }
}
