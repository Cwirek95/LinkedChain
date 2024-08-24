using Dapper;
using LinkedChain.BuildingBlocks.Application.DataAccess;
using LinkedChain.Modules.Recruitment.Application.Configurations.Queries;

namespace LinkedChain.Modules.Recruitment.Application.Offers.GetOfferDetails;

internal class GetOfferDetailsQueryHandler : IQueryHandler<GetOfferDetailsQuery, OfferDetailsDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetOfferDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<OfferDetailsDto> Handle(GetOfferDetailsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return await connection.QuerySingleAsync<OfferDetailsDto>(
            $"""
                 SELECT 
                     [Offers].[Id] AS [{nameof(OfferDetailsDto.Id)}],
                     [Offers].[Employee] AS [{nameof(OfferDetailsDto.EmployeeId)}],
                     [Offers].[Employer] AS [{nameof(OfferDetailsDto.EmployerId)}],
                     [Offers].[Description] AS [{nameof(OfferDetailsDto.Description)}],
                     [Offers].[Status] AS [{nameof(OfferDetailsDto.StatusName)}],
                     [Offers].[ContractType] AS [{nameof(OfferDetailsDto.ContractType)}],
                     [Offers].[ContractStartDate] AS [{nameof(OfferDetailsDto.StartDate)}],
                     [Offers].[ContractEndDate] AS [{nameof(OfferDetailsDto.EndDate)}],
                     [Offers].[SalaryPeriod] AS [{nameof(OfferDetailsDto.SalaryPeriod)}],
                     [Offers].[SalaryCurrency] AS [{nameof(OfferDetailsDto.SalaryCurrency)}],
                     [Offers].[SalaryAmount] AS [{nameof(OfferDetailsDto.SalaryAmount)}],
                 FROM [recruitment].[Offers]
                 WHERE [Offers].[Id] = @OfferId
                 """,
            new
            {
                query.OfferId
            });
    }
}