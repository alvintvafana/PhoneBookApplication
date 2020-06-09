using PhoneBookApplication.Common.Exceptions;
using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Services;
using System.Linq;
using Xunit;

namespace PhoneBookApplication.UnitTest
{
    public class InsertEntryCommandHandlerTest
    {
        private IPhoneBookRepository _phoneBookRepositoryMock;
        private readonly string _phoneBookName = "Test";

        public InsertEntryCommandHandlerTest()
        {
            _phoneBookRepositoryMock = new PhoneBookRepositoryMock();
        }
        
        [Fact]
        public async System.Threading.Tasks.Task InsertEntryCommandHandler_Success()
        {
            //Given
            var phoneBook = new PhoneBookAggregateRoot { Name = _phoneBookName };
            var entryName = "TestUser";
            var entryPhoneNumber = 0817810008;


            await _phoneBookRepositoryMock.AddAsync(phoneBook);
            
            var insertEntryCommandHandler = new InsertEntryCommandHandler(_phoneBookRepositoryMock);
            var insertEntryCommand = new InsertEntryCommand { Name =entryName, PhoneNumber=entryPhoneNumber , PhoneBookId=phoneBook.Id };

            //When
            await insertEntryCommandHandler.HandleAsync(insertEntryCommand);

            //Then
            var entry = ((PhoneBookRepositoryMock)_phoneBookRepositoryMock).phoneBookAggregates.FirstOrDefault().Entries.FirstOrDefault();

            Assert.NotNull(entry);
            Assert.Equal(entryName, entry.Name);
            Assert.Equal(entryPhoneNumber, entry.PhoneNumber);
        }

        [Fact]
        public async System.Threading.Tasks.Task InsertEntryCommandHandler_Fail()
        {
            var entryName = "TestUser";
            var entryPhoneNumber = 111111111;

            var phoneBook = new PhoneBookAggregateRoot { Name = _phoneBookName };
            phoneBook.InsertEntry(entryName, entryPhoneNumber);

            await _phoneBookRepositoryMock.AddAsync(phoneBook);

            var insertEntryCommandHandler = new InsertEntryCommandHandler(_phoneBookRepositoryMock);
            var insertEntryCommand = new InsertEntryCommand { Name = entryName, PhoneNumber = entryPhoneNumber, PhoneBookId = phoneBook.Id };

            await Assert.ThrowsAsync<ValidateException>(() => insertEntryCommandHandler.HandleAsync(insertEntryCommand));
        }
    }
}
