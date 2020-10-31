using System.Reflection;
using Autofac;

namespace Arcaim.CQRS.Commands
{
    public abstract class CommandModule : Autofac.Module
    {
        protected abstract Assembly GetAssembly();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetAssembly())
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}