namespace Charisma.CodeChallenge.Domain.Seedwork;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}