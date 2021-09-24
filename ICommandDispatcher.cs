using System.Threading.Tasks;

namespace Arcaim.CQRS.Commands
{
    internal interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : class, ICommand;
    }
}