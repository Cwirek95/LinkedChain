using LinkedChain.BuildingBlocks.Infrastructure.DataAccess;
using LinkedChain.Modules.Recruitment.Application.Configurations.Commands;
using LinkedChain.Modules.Recruitment.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Processing;

internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
{
    private readonly ICommandHandler<T> _decorated;
    private readonly IUnitOfWork _unitOfWork;
    private readonly RecruitmentContext _recruitmentContext;

    public UnitOfWorkCommandHandlerDecorator(
        ICommandHandler<T> decorated,
        IUnitOfWork unitOfWork,
        RecruitmentContext meetingContext)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
        _recruitmentContext = meetingContext;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        await _decorated.Handle(command, cancellationToken);

        if (command is InternalCommandBase)
        {
            var internalCommand =
                await _recruitmentContext.InternalCommands
                .FirstOrDefaultAsync(
                    x => x.Id == command.Id,
                    cancellationToken: cancellationToken);

            if (internalCommand != null)
            {
                internalCommand.ProcessedDate = DateTime.UtcNow;
            }
        }

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}