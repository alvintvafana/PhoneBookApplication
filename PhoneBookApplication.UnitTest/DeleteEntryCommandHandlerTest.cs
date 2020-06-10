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
    public class DeleteEntryCommandHandlerTest
    {
        private IPhoneBookRepository _phoneBookRepositoryMock;
        private readonly string _phoneBookName = "Test";

        public DeleteEntryCommandHandlerTest()
        {
            _phoneBookRepositoryMock = new PhoneBookRepositoryMock();
        }
        
        [Fact]
        public async System.Threading.Tasks.Task DeleteEntryCommandHandler_Success()
        {
            //Given
            var phoneBook = new PhoneBookAggregateRoot { Name = _phoneBookName };
            phoneBook.InsertEntry("TestUser", "0817810008");
            var entryId = phoneBook.Entries.FirstOrDefault().Id;

            await _phoneBookRepositoryMock.AddAsync(phoneBook);
            
            var deleteEntryCommandHandler = new DeleteEntryCommandHandler(_phoneBookRepositoryMock);
            var deleteEntryCommand = new DeleteEntryCommand { PhoneBookId = phoneBook.Id,EntryId= entryId };

            //When
            await deleteEntryCommandHandler.HandleAsync(deleteEntryCommand);

            //Then
            Assert.Empty(((PhoneBookRepositoryMock)_phoneBookRepositoryMock).phoneBookAggregates.FirstOrDefault().Entries);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteEntryCommandHandler_Fail()
        {
            var phoneBook = new PhoneBookAggregateRoot { Name = _phoneBookName };
            await _phoneBookRepositoryMock.AddAsync(phoneBook);

            var deleteEntryCommandHandler = new DeleteEntryCommandHandler(_phoneBookRepositoryMock);
            var deleteEntryCommand = new DeleteEntryCommand { PhoneBookId = phoneBook.Id, EntryId = Guid.NewGuid() };

            await Assert.ThrowsAsync<ValidateException>(() => deleteEntryCommandHandler.HandleAsync(deleteEntryCommand));
        }
    }
}
