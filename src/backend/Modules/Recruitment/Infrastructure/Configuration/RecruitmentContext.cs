using LinkedChain.BuildingBlocks.Application.Outbox;
using LinkedChain.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration;

internal class RecruitmentContext : DbContext
{
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public DbSet<InternalCommand> InternalCommands { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public RecruitmentContext(DbContextOptions options, ILoggerFactory loggerFactory)
        :base(options)
    {
        _loggerFactory = loggerFactory;
    }
}