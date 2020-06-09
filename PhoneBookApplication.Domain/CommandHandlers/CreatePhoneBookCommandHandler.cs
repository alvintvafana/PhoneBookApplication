using PhoneBookApplication.Common.Exceptions;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Services;
using System.Threading.Tasks;

namespace PhoneBookApplication.Domain.CommandHandlers
{
    public class CreatePhoneBookCommandHandler : ICommandHandler<CreatePhoneBookCommand>
    {
        private IPhoneBookRepository _phoneBookRepository;
        public CreatePhoneBookCommandHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task HandleAsync(CreatePhoneBookCommand command)
        {
            var phoneBook = await _phoneBookRepository.GetPhoneBookByNameAsync(command.Name);
            if (phoneBook != null)
                throw new ValidateException("Phone book already exists");
           await _phoneBookRepository.AddAsync(new Entities.PhoneBookAggregateRoot(command.Name));
            await _phoneBookRepository.SaveAsync();
        }
    }
}
