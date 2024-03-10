using Domain.Entities.TeamMember;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.TeamMember.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.TeamMember;

public class TeamMemberRepository(ApplicationDbContext context) : FullAuditGenericRepository<TeamMemberEntity>(context),
    ITeamMemberRepository;