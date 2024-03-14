using Core.Services.Spectacle.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Spectacle.Queries.GetSpectacleById.DTOs;

public class GetSpectacleByIdQuery: BaseMediatorDtoValidation<GetSpectacleByIdQuery>, IRequest<SpectacleDto>
{
    public string SpectacleId { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.SpectacleId)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}