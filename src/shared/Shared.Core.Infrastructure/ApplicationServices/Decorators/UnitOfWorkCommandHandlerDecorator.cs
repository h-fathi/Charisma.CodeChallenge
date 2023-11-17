using Shared.Core.Contracts;

namespace Shared.Core.Infrastructure.ApplicationServices;

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _commandHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork)
    {
        _commandHandler = commandHandler;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        await _commandHandler.HandleAsync(command, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new Result(true);
    }
}