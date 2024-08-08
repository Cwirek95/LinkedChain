using LinkedChain.BuildingBlocks.Domain.Exceptions;
using LinkedChain.BuildingBlocks.Domain;
using MediatR;
using NUnit.Framework;
using Serilog;
using System.Data;
using LinkedChain.Modules.Recruitment.Application.Contracts;
using LinkedChain.BuildingBlocks.IntegrationTests;
using System.Data.SqlClient;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration;
using LinkedChain.Modules.Recruitment.Infrastructure;
using LinkedChain.Modules.Recruitment.Domain.SharedKernel;
using Dapper;
using LinkedChain.BuildingBlocks.IntegrationTests.Probing;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;

public class TestBase
{
    protected string ConnectionString { get; private set; }

    protected ILogger Logger { get; private set; }

    protected IRecruitmentModule RecruitmentModule { get; private set; }

    protected ExecutionContextMock ExecutionContext { get; private set; }

    protected IServiceCollection Services { get; private set; }

    [SetUp]
    public async Task BeforeEachTest()
    {
        const string connectionStringEnvironmentVariable =
            "ASPNETCORE_LinkedChain_IntegrationTests_ConnectionString";
        ConnectionString = EnvironmentVariablesProvider.GetVariable(connectionStringEnvironmentVariable);
        if (ConnectionString == null)
        {
            throw new ApplicationException(
                $"Define connection string to integration tests database using environment variable: {connectionStringEnvironmentVariable}");
        }

        using (var sqlConnection = new SqlConnection(ConnectionString))
        {
            await ClearDatabase(sqlConnection);
        }

        Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        ExecutionContext = new ExecutionContextMock(Guid.NewGuid());

        RecruitmentStartup.Initialize(
            Services,
            ConnectionString,
            ExecutionContext,
            Logger,
            new EventsBusMock());

        RecruitmentModule = new RecruitmentModule();
    }

    [TearDown]
    public void AfterEachTest()
    {
        RecruitmentStartup.Stop();
        SystemClock.Reset();
    }

    protected async Task ExecuteScript(string scriptPath)
    {
        var sql = await File.ReadAllTextAsync(scriptPath);

        await using var sqlConnection = new SqlConnection(ConnectionString);
        await sqlConnection.ExecuteScalarAsync(sql);
    }

    protected async Task<T> GetLastOutboxMessage<T>()
        where T : class, INotification
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var messages = await OutboxMessagesHelper.GetOutboxMessages(connection);

            return OutboxMessagesHelper.Deserialize<T>(messages.Last());
        }
    }

    protected static void AssertBrokenRule<TRule>(AsyncTestDelegate testDelegate)
        where TRule : class, IBusinessRule
    {
        var message = $"Expected {typeof(TRule).Name} broken rule";
        var businessRuleValidationException = Assert.CatchAsync<BusinessRuleValidationException>(testDelegate, message);
        if (businessRuleValidationException != null)
        {
            Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
        }
    }

    protected static async Task AssertEventually(IProbe probe, int timeout)
    {
        await new Poller(timeout).CheckAsync(probe);
    }

    private static async Task ClearDatabase(IDbConnection connection)
    {
        const string sql = "DELETE FROM [recruitment].[InboxMessages] " +
                           "DELETE FROM [recruitment].[InternalCommands] " +
                           "DELETE FROM [recruitment].[OutboxMessages] " +
                           "DELETE FROM [recruitment].[Offers] ";

        await connection.ExecuteScalarAsync(sql);
    }
}