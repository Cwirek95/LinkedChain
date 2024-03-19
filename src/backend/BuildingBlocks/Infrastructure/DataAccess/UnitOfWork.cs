using Microsoft.EntityFrameworkCore;

namespace LinkedChain.BuildingBlocks.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default, Guid? internalCommandId = null)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}