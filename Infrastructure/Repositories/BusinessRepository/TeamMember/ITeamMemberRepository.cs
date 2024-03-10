﻿using Domain.Entities.TeamMember;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.TeamMember;

public interface ITeamMemberRepository : IFullAuditGenericRepository<TeamMemberEntity>;