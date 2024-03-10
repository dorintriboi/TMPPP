using Domain.Entities.Team;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Team;

public interface ITeamRepository : IFullAuditGenericRepository<TeamEntity>;