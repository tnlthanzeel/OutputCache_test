using OutputCache_test.SharedKernal.Models;

namespace OutputCache_test.SharedKernal.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents, bool isPrePersistantDomainEvent);
}
