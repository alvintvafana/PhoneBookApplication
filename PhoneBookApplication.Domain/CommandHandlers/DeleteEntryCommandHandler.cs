using PhoneBookApplication.Common.Exceptions;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApplication.Domain.CommandHandlers
{
   public class DeleteEntryCommandHandler : ICommandHandler<DeleteEntryCommand>
    {
        private IPhoneBookRepository _phoneBookRepository;
        public DeleteEntryCommandHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task HandleAsync(DeleteEntryCommand command)
        {
            var phoneBook = await _phoneBookRepository.GetPhoneBookByIdAsync(command.PhoneBookId);
           
            phoneBook.DeleteEntry(command.EntryId);
             _phoneBookRepository.Update(phoneBook);
            await _phoneBookRepository.SaveAsync();
        }
    }
}
