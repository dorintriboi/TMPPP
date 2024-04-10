using Core.Services.Playlist.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Playlist.Command.GetPlaylistById.DTOs;

public class GetPlaylistByIdQuery: BaseMediatorDtoValidation<GetPlaylistByIdQuery>, IRequest<PlaylistDto>
{
    public string PlaylistId { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.PlaylistId)
            .NotEmpty()
            .WithMessage("Name most be not null");
    }
}