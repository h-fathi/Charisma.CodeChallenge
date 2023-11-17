using Shared.Core.Contracts.ApplicationServices;

namespace Charisma.CodeChallenge.Application.Customers;

public class CreateCustomerCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
}