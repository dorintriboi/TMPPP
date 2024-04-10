using Domain.Entities.Music;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Music.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Music;

public class MusicRepository (ApplicationDbContext context) : FullAuditGenericRepository<MusicEntity>(context),
    IMusicRepository;