using System;
using Microsoft.Extensions.DependencyInjection;

namespace Arcaim.CQRS.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}