using Autofac;
using Autofac.Core.Registration;

namespace Arcaim.CQRS.Commands
{
    public static class Extensions
    {
        public static IModuleRegistrar RegisterCommandsModule(this IModuleRegistrar builder)
        {
            return builder.RegisterModule<CommandModule>();
        }
    }
}