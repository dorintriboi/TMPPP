using Core.Services.Team.Common;
using Core.Services.Team.Queries.GetTeamBySpectacleType.DTOs;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Team.Queries.GetTeamBySpectacleType;

public class GetTeamBySpectacleTypeHandler(IApplicationUnitOfWork repository) : IRequestHandler<GetTeamBySpectacleTypeQuery, TeamDto>
{
    public async Task<TeamDto> Handle(GetTeamBySpectacleTypeQuery request, CancellationToken cancellationToken)
    {
        var team = await repository.TeamRepository.GetBySpectacleTypeAsync(request.Type);

        return TeamDto.From(team);
    }
}