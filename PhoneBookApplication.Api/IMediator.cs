using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Queries;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api
{
    public interface IMediator
    {
        Task DispatchAsync(ICommand command);
        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}
