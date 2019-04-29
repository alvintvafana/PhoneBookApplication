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
   public class InsertEntryCommandHandler : ICommandHandler<InsertEntryCommand>
    {
        private IPhoneBookRepository _phoneBookRepository;
        public InsertEntryCommandHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task HandleAsync(InsertEntryCommand command)
        {
            var phoneBook = await _phoneBookRepository.GetPhoneBookByIdAsync(command.PhoneBookId);
            if (phoneBook.Entries.Where(a=>a.Name ==command.Name && a.PhoneNumber==command.PhoneNumber).Any())
                throw new ValidateException("Phone book entry already exists");
            phoneBook.InsertEntry(command.Name, command.PhoneNumber);
             _phoneBookRepository.Update(phoneBook);
            await _phoneBookRepository.SaveAsync();
        }
    }
}
