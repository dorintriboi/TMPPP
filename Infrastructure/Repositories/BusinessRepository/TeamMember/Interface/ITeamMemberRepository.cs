﻿using Domain.Entities.TeamMember;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.TeamMember.Interface;

public interface ITeamMemberRepository : IFullAuditGenericRepository<TeamMemberEntity>;