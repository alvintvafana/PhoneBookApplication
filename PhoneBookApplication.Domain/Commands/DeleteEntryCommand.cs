using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Domain.Commands
{
   public class DeleteEntryCommand : ICommand
    {
        public Guid PhoneBookId { get; set; }
        public Guid EntryId { get; set; }
    }
}
