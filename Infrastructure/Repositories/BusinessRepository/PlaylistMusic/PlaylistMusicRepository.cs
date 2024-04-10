using Domain.Entities.PlaylistMusic;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.PlaylistMusic.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.PlaylistMusic;

public class PlaylistMusicRepository(ApplicationDbContext context) : FullAuditGenericRepository<PlaylistMusicEntity>(context),
    IPlaylistMusicRepository;