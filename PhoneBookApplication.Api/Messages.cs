using Microsoft.Extensions.DependencyInjection;
using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Queries;
using PhoneBookApplication.Domain.QueryHandlers;
using System;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api
{
    public sealed class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task DispatchAsync(ICommand command)
        {
            using (var scope = _provider.CreateScope())
            {
                Type type = typeof(ICommandHandler<>);
                Type[] typeArgs = { command.GetType() };
                Type handlerType = type.MakeGenericType(typeArgs);

                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
                await handler.HandleAsync((dynamic)command);
            }
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query)
        {
            using (var scope = _provider.CreateScope())
            {
                Type type = typeof(IQueryHandler<,>);
                Type[] typeArgs = { query.GetType(), typeof(T) };
                Type handlerType = type.MakeGenericType(typeArgs);

                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);
                T result = await handler.HandleAsync((dynamic)query);

                return result;
            }
        }
    }
}

