using Core.Services.Spectacle.Queries.GetSpectacleById.DTOs;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Spectacle.Queries.GetMusicBySpectacleId.DTOs;

public class GetMusicBySpectacleIdQuery: BaseMediatorDtoValidation<GetSpectacleByIdQuery>, IRequest<IEnumerable<MusicDto>>
{
    public string SpectacleId { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.SpectacleId)
            .NotEmpty()
            .WithMessage("SpectacleId is required");
    }
}