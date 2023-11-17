using Autofac;
using Microsoft.Extensions.Configuration;

namespace Shared.Core.Infrastructure.Autofac;

public abstract class BaseAutofacConfig
{
    protected readonly ContainerBuilder _builder;
    protected readonly IConfiguration _configuration;

    public abstract void SetConfig();

    public BaseAutofacConfig(ContainerBuilder builder, IConfiguration configuration)
    {
        _builder = builder;
        _configuration = configuration;
    }
}
