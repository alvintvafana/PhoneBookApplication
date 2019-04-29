using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api.Dtos
{
    public class DeleteEntryDto
    {
        public Guid PhoneBookId { get; set; }
        public Guid EntryId { get; set; }
    }
}
