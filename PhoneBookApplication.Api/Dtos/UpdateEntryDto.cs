using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api.Dtos
{
    public class UpdateEntryDto
    {
        public Guid PhoneBookId { get; set; }
        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
    }
}
