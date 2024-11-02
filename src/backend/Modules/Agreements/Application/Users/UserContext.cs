using LinkedChain.BuildingBlocks.Application;
using LinkedChain.Modules.Agreements.Domain.Users;

namespace LinkedChain.Modules.Agreements.Application.Users;

public class UserContext : IUserContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public UserContext(IExecutionContextAccessor executionContextAccessor)
    {
        _executionContextAccessor = executionContextAccessor;
    }

    public UserId UserId => new UserId(_executionContextAccessor.UserId);
}