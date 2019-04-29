using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Domain.Commands
{
   public class UpdateEntryCommand : ICommand
    {
        public Guid PhoneBookId { get; set; }

        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
    }
}
