using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Arcaim.CQRS.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

            GetAssemblies().SelectMany(assembly => assembly.GetTypes()
                .Where(type => !type.IsInterface && !type.IsAbstract && type.GetInterfaces()
                .Any(y => y.Name.Equals(typeof(ICommandHandler<>).Name, StringComparison.InvariantCulture))))
                .ToList().ForEach(type => type.GetInterfaces()
                .ToList().ForEach(implementedInterfaces =>
                    services.AddTransient(implementedInterfaces, type)
                ));

            return services;
        }

        private static IEnumerable<Assembly> GetAssemblies()
            => Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x)));
    }
}