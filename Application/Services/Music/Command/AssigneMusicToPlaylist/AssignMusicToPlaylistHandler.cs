using Core.Services.Music.Command.AssigneMusicToPlaylist.DTOs;
using Domain.Entities.PlaylistMusic;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Music.Command.AssigneMusicToPlaylist;

public class AssignMusicToPlaylistHandler(IApplicationUnitOfWork repository) : IRequestHandler<DTOs.AssignMusicToPlaylistCommand>
{
    public async Task Handle(AssignMusicToPlaylistCommand request, CancellationToken cancellationToken)
    {
        var music = await repository.MusicRepository.GetByIdAsync(request.MusicId);
        var playlist = await repository.PlaylistRepository.GetByIdAsync(request.PlaylistId);

        var playlistMusic = new PlaylistMusicEntity();
        playlistMusic.Type = ReferenceType.Music;
        playlistMusic.ReferenceId = music.Id;

        playlist.Music.Add(playlistMusic);

        await repository.SaveAsync();
    }
}