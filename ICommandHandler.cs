using System.Threading.Tasks;

namespace Arcaim.CQRS.Commands;

public interface ICommandHandler<in T> where T : class, ICommand
{
  Task HandleAsync(T command);
}