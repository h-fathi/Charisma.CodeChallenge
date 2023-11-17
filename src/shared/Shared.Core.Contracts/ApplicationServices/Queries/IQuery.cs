namespace Shared.Core.Contracts.ApplicationServices;

// Marker interface
public interface IQuery
{
}

public interface IQuery<TQuery> : IQuery
{
}