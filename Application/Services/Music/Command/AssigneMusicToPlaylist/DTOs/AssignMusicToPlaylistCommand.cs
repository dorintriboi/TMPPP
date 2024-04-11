using Core.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Services.Music.Command.AssigneMusicToPlaylist.DTOs;

public class AssignMusicToPlaylistCommand: BaseMediatorDtoValidation<AssignMusicToPlaylistCommand>, IRequest
{
    public string MusicId { get; set; }
    public string PlaylistId { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.MusicId)
            .NotEmpty()
            .WithMessage("MusicId most be not null");
        
        RuleFor(x => x.PlaylistId)
            .NotEmpty()
            .WithMessage("PlaylistId most be not null");
    }
}