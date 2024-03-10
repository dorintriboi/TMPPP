using Domain.Entities.Spectacle;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Spectacle.Interface;

public interface ISpectacleRepository : IFullAuditGenericRepository<SpectacleEntity>;