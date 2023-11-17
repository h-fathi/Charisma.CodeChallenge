namespace Shared.Core.Contracts.ApplicationServices;

public interface ICommandDispatcher
{
    Task<Result> SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand;
}