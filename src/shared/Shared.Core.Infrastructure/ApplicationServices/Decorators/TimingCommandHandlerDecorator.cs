using Shared.Core.Contracts;

namespace Shared.Core.Infrastructure.ApplicationServices;

internal sealed class TimingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ILogger<TimingCommandHandlerDecorator<TCommand>> _logger;
    private readonly ICommandHandler<TCommand> _commandHandler;

    public TimingCommandHandlerDecorator(ILogger<TimingCommandHandlerDecorator<TCommand>> logger,
        ICommandHandler<TCommand> commandHandler)
    {
        _logger = logger;
        _commandHandler = commandHandler;
    }

    public async Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
    {
        var startTime = DateTime.Now;

       var result = await _commandHandler.HandleAsync(command, cancellationToken);

        var endTime = DateTime.Now;
        var executionTime = endTime - startTime;

        _logger.LogInformation($"Execution time: {executionTime}");

        return result;
    }
}