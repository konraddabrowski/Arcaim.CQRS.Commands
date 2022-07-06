using System.Threading.Tasks;

namespace Arcaim.CQRS.Commands;

public interface ICommandHandler<in T> where T : ICommand, new()
{
  Task HandleAsync(T command);
}