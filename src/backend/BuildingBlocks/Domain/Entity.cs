using LinkedChain.BuildingBlocks.Domain.Events;
using LinkedChain.BuildingBlocks.Domain.Exceptions;

namespace LinkedChain.BuildingBlocks.Domain;

public abstract class Entity
{
    private List<IDomainEvent>? _domainEvents;
    
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly();
    
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
    
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();

        _domainEvents.Add(domainEvent);
    }

    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}