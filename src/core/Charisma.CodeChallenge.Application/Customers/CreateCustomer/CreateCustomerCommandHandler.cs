using Shared.Core.Contracts;

namespace Charisma.CodeChallenge.Application.Customers;

internal class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> HandleAsync(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var customer = Customer.Create(command.FirstName, command.LastName, new Address(command.Street, command.City, command.Country));

        await _customerRepository.Create(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new Result(true);
    }
}
