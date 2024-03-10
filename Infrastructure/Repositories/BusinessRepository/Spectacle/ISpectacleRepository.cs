using Domain.Entities.Spectacle;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Spectacle;

public interface ISpectacleRepository : IFullAuditGenericRepository<SpectacleEntity>;