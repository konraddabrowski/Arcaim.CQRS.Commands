using Arcaim.DI.Scanner;
using Microsoft.Extensions.DependencyInjection;

namespace Arcaim.CQRS.Commands;

public static class Extensions
{
  public static IServiceCollection AddCommandSeparation(this IServiceCollection services)
  {
    services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
    services.Scan(a => a.ByAppAssemblies()
      .ImplementationOf(typeof(ICommandHandler<>))
      .WithTransientLifetime());

    return services;
  }
}