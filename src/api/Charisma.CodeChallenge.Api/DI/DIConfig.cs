using Charisma.CodeChallenge.Application;
using Shared.Core.Contracts.ApplicationServices;

namespace Charisma.CodeChallenge.Api.Infrastructure;

public class DIConfig : BaseAutofacConfig
{
    public DIConfig(ContainerBuilder builder, IConfiguration configuration) : base(builder, configuration)
    {
    }

    public override void SetConfig()
    {
        _builder.RegisterType<CommandDispatcher>()
            .As<ICommandDispatcher>()
        .InstancePerLifetimeScope();

        _builder.RegisterType<QueryDispatcher>()
            .As<IQueryDispatcher>()
            .InstancePerLifetimeScope();

        _builder.RegisterType<InMemoryDispatcher>()
            .As<IDispatcher>()
            .InstancePerLifetimeScope();

        _builder.Register(ctx =>
        {
            var context = ctx.Resolve<OrderDbContext>();

            return new UnitOfWork<OrderDbContext>(context);
        })
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        _builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
            .Where(type => typeof(IRepository).IsAssignableFrom(type))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        _builder.RegisterAssemblyTypes(typeof(ApplicationModule).Assembly)
            .AsImplementedInterfaces()
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .InstancePerLifetimeScope();

        _builder.RegisterAssemblyTypes(typeof(ApplicationModule).Assembly)
            .AsImplementedInterfaces()
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .InstancePerLifetimeScope();
    }
}
