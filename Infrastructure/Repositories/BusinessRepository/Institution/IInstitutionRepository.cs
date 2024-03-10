﻿using Domain.Entities.Institution;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Institution;

public interface IInstitutionRepository : IFullAuditGenericRepository<InstitutionEntity>;