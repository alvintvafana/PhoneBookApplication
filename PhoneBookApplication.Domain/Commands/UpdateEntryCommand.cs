using System;

namespace PhoneBookApplication.Domain.Commands
{
    public class UpdateEntryCommand : ICommand
    {
        public Guid PhoneBookId { get; set; }

        public Guid EntryId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
