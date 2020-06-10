using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Domain.Commands
{
   public class InsertEntryCommand : ICommand
    {
        public Guid PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
