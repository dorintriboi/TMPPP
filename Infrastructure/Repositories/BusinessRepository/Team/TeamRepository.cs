using Domain.Entities.Spectacle.Enum;
using Domain.Entities.Team;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Team.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BusinessRepository.Team;

public class TeamRepository(ApplicationDbContext context) : FullAuditGenericRepository<TeamEntity>(context),
    ITeamRepository
{
    public async Task<TeamEntity?> GetBySpectacleTypeAsync(SpectacleType type)
    {
        return await context.Teams.Where(x => x.Spectacles.Any(y => y.Spectacle.Type == type)).FirstOrDefaultAsync();
    }
}