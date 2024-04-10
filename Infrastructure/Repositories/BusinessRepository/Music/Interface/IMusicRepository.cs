using Domain.Entities.Music;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Music.Interface;

public interface IMusicRepository: IFullAuditGenericRepository<MusicEntity>;