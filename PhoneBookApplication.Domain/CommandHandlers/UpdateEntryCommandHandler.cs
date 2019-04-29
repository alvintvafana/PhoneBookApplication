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
   public class UpdateEntryCommandHandler : ICommandHandler<UpdateEntryCommand>
    {
        private IPhoneBookRepository _phoneBookRepository;
        public UpdateEntryCommandHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task HandleAsync(UpdateEntryCommand command)
        {
            var phoneBook = await _phoneBookRepository.GetPhoneBookByIdAsync(command.PhoneBookId);
           
            phoneBook.UpdateEntry(command.EntryId, command.Name, command.PhoneNumber);
             _phoneBookRepository.Update(phoneBook);
            await _phoneBookRepository.SaveAsync();
        }
    }
}
