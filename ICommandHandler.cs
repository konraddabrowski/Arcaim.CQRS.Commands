using System.Threading.Tasks;

namespace Arcaim.CQRS.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}