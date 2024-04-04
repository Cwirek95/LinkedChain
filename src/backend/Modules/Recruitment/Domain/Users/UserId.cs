using LinkedChain.BuildingBlocks.Domain;

namespace LinkedChain.Modules.Recruitment.Domain.Users;

public class UserId : TypedIdValueBase
{
    public UserId(Guid value)
        : base(value)
    {
    }
}