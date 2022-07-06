using System.Threading.Tasks;

namespace Arcaim.CQRS.Commands;

public interface ICommandDispatcher
{
  Task DispatchAsync<T>(T command) where T : ICommand, new();
}