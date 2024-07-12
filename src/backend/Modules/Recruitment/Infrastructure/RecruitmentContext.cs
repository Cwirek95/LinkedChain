using LinkedChain.BuildingBlocks.Application.Outbox;
using LinkedChain.BuildingBlocks.Infrastructure.InternalCommands;
using LinkedChain.Modules.Recruitment.Domain.Offer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinkedChain.Modules.Recruitment.Infrastructure;

internal class RecruitmentContext : DbContext
{
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    public DbSet<InternalCommand> InternalCommands { get; set; }
    public DbSet<Offer> Offers { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public RecruitmentContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}