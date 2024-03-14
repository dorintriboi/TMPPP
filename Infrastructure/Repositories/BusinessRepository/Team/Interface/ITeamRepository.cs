using Domain.Entities.Spectacle.Enum;
using Domain.Entities.Team;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Team.Interface;

public interface ITeamRepository : IFullAuditGenericRepository<TeamEntity>
{
    Task<TeamEntity?> GetBySpectacleTypeAsync(SpectacleType type);
};