using System;
using System.Threading.Tasks;
using Autofac;

namespace Arcaim.CQRS.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Command '{typeof(T).Name}' can not be null");
            }
            await _componentContext.Resolve<ICommandHandler<T>>()
                                   .HandleAsync(command);
        }
    }
}