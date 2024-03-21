using LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;
using Microsoft.EntityFrameworkCore;

namespace LinkedChain.BuildingBlocks.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UnitOfWork(DbContext context, IDomainEventsDispatcher domainEventsDispatcher)
    {
        _context = context;
        _domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default, Guid? internalCommandId = null)
    {
        await _domainEventsDispatcher.DispatchEventsAsync();
        
        return await _context.SaveChangesAsync(cancellationToken);
    }
}