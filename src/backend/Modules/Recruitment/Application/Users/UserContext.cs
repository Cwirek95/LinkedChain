using LinkedChain.BuildingBlocks.Application;
using LinkedChain.Modules.Recruitment.Domain.Users;

namespace LinkedChain.Modules.Recruitment.Application.Users;

public class UserContext : IUserContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public UserContext(IExecutionContextAccessor executionContextAccessor)
    {
        _executionContextAccessor = executionContextAccessor;
    }

    public UserId UserId => new UserId(_executionContextAccessor.UserId);
}