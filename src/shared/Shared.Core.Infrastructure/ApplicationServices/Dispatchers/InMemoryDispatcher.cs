using Shared.Core.Contracts;

namespace Shared.Core.Infrastructure.ApplicationServices;

public sealed class InMemoryDispatcher : IDispatcher
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public InMemoryDispatcher(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    public async Task<Result> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand
    {
       return await _commandDispatcher.SendAsync(command, cancellationToken);
    }

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        return await _queryDispatcher.QueryAsync(query, cancellationToken);
    }
}