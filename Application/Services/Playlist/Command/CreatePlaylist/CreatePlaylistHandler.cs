using Core.Services.Playlist.Command.CreatePlaylist.DTOs;
using Core.Services.Playlist.Common;
using Domain.Entities.Playlist;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Playlist.Command.CreatePlaylist;

public class CreatePlaylistHandler(IApplicationUnitOfWork repository) : IRequestHandler<CreatePlaylistCommand, PlaylistDto>
{
    public async Task<PlaylistDto> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var playlist = new PlaylistEntity()
        {
            Name = request.Name
        };

        await repository.PlaylistRepository.InsertAsync(playlist);
        await repository.SaveAsync();

        return new PlaylistDto() { Name = request.Name };
    }
}