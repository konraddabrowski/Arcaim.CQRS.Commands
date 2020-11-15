using System.Threading.Tasks;

namespace Arcaim.CQRS.Commands
{
    public interface ICommandDispatcher
    {
        Task HandleAsync<T>(T command) where T : ICommand;
    }
}