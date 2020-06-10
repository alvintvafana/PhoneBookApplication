using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Common.Exceptions;

namespace PhoneBookApplication.UnitTest
{
    public class CreatePhoneBookCommandHandlerTest
    {
        private IPhoneBookRepository _phoneBookRepositoryMock;
        private readonly string _phoneBookName = "Test";

        public CreatePhoneBookCommandHandlerTest()
        {
            _phoneBookRepositoryMock = new PhoneBookRepositoryMock();
        }
        
        [Fact]
        public async System.Threading.Tasks.Task CreatePhoneBookCommandHandler_Success()
        {
            //Given
            var createPhoneBookCommandHandler = new CreatePhoneBookCommandHandler(_phoneBookRepositoryMock);
            var createPhoneBookCommand = new CreatePhoneBookCommand
            {
                Name = _phoneBookName
            };

            //When
            await createPhoneBookCommandHandler.HandleAsync(createPhoneBookCommand);

            //Then
            Assert.Contains(((PhoneBookRepositoryMock)_phoneBookRepositoryMock).phoneBookAggregates, a => a.Name == _phoneBookName);
        }

        [Fact]
        public async System.Threading.Tasks.Task CreatePhoneBookCommandHandler_Fail()
        {
            //Given
            var createPhoneBookCommandHandler = new CreatePhoneBookCommandHandler(_phoneBookRepositoryMock);
            await _phoneBookRepositoryMock.AddAsync(new PhoneBookAggregateRoot { Name = _phoneBookName });

            var createPhoneBookCommand = new CreatePhoneBookCommand
            {
                Name = _phoneBookName
            };

            //When
            await Assert.ThrowsAsync<ValidateException>(() => createPhoneBookCommandHandler.HandleAsync(createPhoneBookCommand));
        }
    }
}
