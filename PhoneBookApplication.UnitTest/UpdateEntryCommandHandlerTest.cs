using PhoneBookApplication.Common.Exceptions;
using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Services;
using System.Linq;
using Xunit;

namespace PhoneBookApplication.UnitTest
{
    public class UpdateEntryCommandHandlerTest
    {
        private IPhoneBookRepository _phoneBookRepositoryMock;
        private readonly string _phoneBookName = "Test";

        public UpdateEntryCommandHandlerTest()
        {
            _phoneBookRepositoryMock = new PhoneBookRepositoryMock();
        }
        
        [Fact]
        public async System.Threading.Tasks.Task UpdateEntryCommandHandlerTest_Success()
        {
            //Given
            var entryName = "TestUser";
            var entryPhoneNumber = "0817810008";
            var entryName2= "TestUser2";

            var phoneBook = new PhoneBookAggregateRoot { Name = _phoneBookName };
            phoneBook.InsertEntry(entryName, entryPhoneNumber);
            var entryId = phoneBook.Entries.FirstOrDefault().Id;

            await _phoneBookRepositoryMock.AddAsync(phoneBook);

            var updateEntryCommandHandler = new UpdateEntryCommandHandler(_phoneBookRepositoryMock);
            var updateEntryCommand = new UpdateEntryCommand { Name = entryName2, PhoneNumber=entryPhoneNumber , PhoneBookId=phoneBook.Id , EntryId=entryId};

            //When
            await updateEntryCommandHandler.HandleAsync(updateEntryCommand);

            //Then
            var entry = ((PhoneBookRepositoryMock)_phoneBookRepositoryMock).phoneBookAggregates.FirstOrDefault().Entries.FirstOrDefault();

            Assert.NotNull(entry);
            Assert.Equal(entryName2, entry.Name);
            Assert.Equal(entryPhoneNumber, entry.PhoneNumber);
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateEntryCommandHandlerTest_Fail()
        {
            var entryName = "TestUser";
            var entryPhoneNumber = "0817810008";

            var phoneBook = new PhoneBookAggregateRoot { Name = _phoneBookName };
            phoneBook.InsertEntry(entryName, entryPhoneNumber);
            var entryId = phoneBook.Entries.FirstOrDefault().Id;

            await _phoneBookRepositoryMock.AddAsync(phoneBook);

            var updateEntryCommandHandler = new UpdateEntryCommandHandler(_phoneBookRepositoryMock);
            var updateEntryCommand = new UpdateEntryCommand { Name = null, PhoneNumber = entryPhoneNumber, PhoneBookId = phoneBook.Id, EntryId = entryId };

            await Assert.ThrowsAsync<ValidateException>(() => updateEntryCommandHandler.HandleAsync(updateEntryCommand));
        }
    }
}
