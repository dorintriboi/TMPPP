using Domain.Entities.Spectacle;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Spectacle;

public class SpectacleRepository(ApplicationDbContext context) : FullAuditGenericRepository<SpectacleEntity>(context),
    ISpectacleRepository;