using Core.Services.Playlist.Common;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Playlist.Command.CreatePlaylist.DTOs;

public class CreatePlaylistCommand: BaseMediatorDtoValidation<CreatePlaylistCommand>, IRequest<PlaylistDto>
{
    public string Name { get; set; }
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
    }
}