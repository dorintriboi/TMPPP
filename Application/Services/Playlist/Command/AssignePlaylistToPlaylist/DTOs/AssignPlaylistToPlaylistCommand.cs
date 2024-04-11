using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Playlist.Command.AssignePlaylistToPlaylist.DTOs;

public class AssignPlaylistToPlaylistCommand: BaseMediatorDtoValidation<AssignPlaylistToPlaylistCommand>, IRequest
{
    public string PlaylistId { get; set; }
    public string ReferencePlaylistId { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.ReferencePlaylistId)
            .NotEmpty()
            .WithMessage("ReferencePlaylistId most be not null");
        
        RuleFor(x => x.PlaylistId)
            .NotEmpty()
            .WithMessage("PlaylistId most be not null");
    }
}