using Core.Services.Team.Common;
using Core.Validations;
using Domain.Entities.Spectacle.Enum;
using FluentValidation;
using MediatR;

namespace Core.Services.Team.Queries.GetTeamBySpectacleType.DTOs;

public class GetTeamBySpectacleTypeQuery: BaseMediatorDtoValidation<GetTeamBySpectacleTypeQuery>, IRequest<TeamDto>
{
    public SpectacleType Type { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type most be not null");
    }
}