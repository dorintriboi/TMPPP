using Core.Services.Playlist.Common;
using Core.Services.Playlist.Queries.GetPlaylistById.DTOs;
using Domain.Entities.Playlist;
using Domain.Entities.PlaylistMusic;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Playlist.Queries.GetPlaylistById;

public class GetPlaylistByIdHandler(IApplicationUnitOfWork repository) : IRequestHandler<GetPlaylistByIdQuery, PlaylistDto>
{
    public async Task<PlaylistDto> Handle(GetPlaylistByIdQuery request, CancellationToken cancellationToken)
    {
        var playlist = await repository.PlaylistRepository.GetByIdAsync(request.PlaylistId);
        var playlistComponent = new Common.CompositePattern.Playlist(playlist.Name);
        playlistComponent = await GetMusicPlaylist(playlist, playlistComponent);

        return new PlaylistDto()
        {
            Name = playlist.Name,
            Music = playlistComponent.GetName()
        };
    }

    private async Task<Common.CompositePattern.Playlist> GetMusicPlaylist(PlaylistEntity playlist, Common.CompositePattern.Playlist playlistComponent)
    {
        foreach (var music in playlist.Music)
        {
            if (music.Type == ReferenceType.Music)
            {
                var musicDb = await repository.MusicRepository.GetByIdAsync(music.ReferenceId);
                var musicComponent = new Common.CompositePattern.Music(musicDb.Name, musicDb.Base64);
                playlistComponent.Add(musicComponent);
            }
            else
            {
                var playlistDb = await repository.PlaylistRepository.GetByIdAsync(music.ReferenceId);
                playlistComponent = await GetMusicPlaylist(playlistDb, playlistComponent);
            }
        }

        return playlistComponent;
    }
}