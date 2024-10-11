using LinkedChain.BuildingBlocks.Application.Outbox;
using LinkedChain.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinkedChain.Modules.Agreements.Infrastructure;

internal class AgreementsContext : DbContext
{
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    public DbSet<InternalCommand> InternalCommands { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public AgreementsContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}