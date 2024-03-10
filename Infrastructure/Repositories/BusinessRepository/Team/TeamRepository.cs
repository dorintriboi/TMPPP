using Domain.Entities.Team;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Team;

public class TeamRepository(ApplicationDbContext context) : FullAuditGenericRepository<TeamEntity>(context),
    ITeamRepository;