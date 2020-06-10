using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api.Dtos
{
    public class InsertEntryDto
    {
        public Guid PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
