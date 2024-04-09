using Domain.Entities.Playlist;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Playlist.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Playlist;

public class PlaylistRepository(ApplicationDbContext context) : FullAuditGenericRepository<PlaylistEntity>(context),
    IPlaylistRepository;