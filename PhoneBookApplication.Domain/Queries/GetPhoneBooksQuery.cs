using PhoneBookApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Domain.Queries
{
   public class GetPhoneBooksQuery :IQuery<IEnumerable<PhoneBookAggregateRoot>>
    {
    }
}
