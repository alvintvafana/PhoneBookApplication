using Microsoft.Extensions.DependencyInjection;
using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Queries;
using PhoneBookApplication.Domain.QueryHandlers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _provider;

        public Mediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task DispatchAsync(ICommand command)
        {
            using (var scope = _provider.CreateScope())
            {
                var commandType = command.GetType();
                var handlerType =
                    typeof(ICommandHandler<>).MakeGenericType(commandType);

                object handler = scope.ServiceProvider.GetRequiredService(handlerType);

                var handleMethod = handlerType.GetMethods()
                    .Single(s => s.Name == nameof(ICommandHandler<ICommand>.HandleAsync));

                Task result = (Task)handleMethod.Invoke(handler, new[] { command });
                await result;

            }
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query)
        {
            using (var scope = _provider.CreateScope())
            {
                Type type = typeof(IQueryHandler<,>);
                Type[] typeArgs = { query.GetType(), typeof(T) };
                Type handlerType = type.MakeGenericType(typeArgs);

                object handler = scope.ServiceProvider.GetRequiredService(handlerType);

                var handleMethod = handlerType.GetMethods()
                    .Single(s => s.Name == nameof(IQueryHandler<IQuery<T>, T>.HandleAsync));

                Task<T> result = (Task<T>)handleMethod.Invoke(handler, new[] { query });
                return await result;
            }
        }
    }
}

