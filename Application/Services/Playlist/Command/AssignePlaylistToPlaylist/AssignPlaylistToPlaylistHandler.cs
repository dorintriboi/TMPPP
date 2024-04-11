using Core.Services.Playlist.Command.AssignePlaylistToPlaylist.DTOs;
using Domain.Entities.PlaylistMusic;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Playlist.Command.AssignePlaylistToPlaylist;

public class AssignPlaylistToPlaylistHandler(IApplicationUnitOfWork repository) : IRequestHandler<DTOs.AssignPlaylistToPlaylistCommand>
{
    public async Task Handle(AssignPlaylistToPlaylistCommand request, CancellationToken cancellationToken)
    {
        var playlist = await repository.PlaylistRepository.GetByIdAsync(request.PlaylistId);
        var playlistReference = await repository.PlaylistRepository.GetByIdAsync(request.ReferencePlaylistId);
        
        var playlistMusic = new PlaylistMusicEntity();
        playlistMusic.Type = ReferenceType.Playlist;
        playlistMusic.ReferenceId = playlistReference.Id;

        playlist.Music.Add(playlistMusic);

        await repository.SaveAsync();
    }
}